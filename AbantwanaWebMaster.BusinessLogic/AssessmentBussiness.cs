using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbantwanaWebMaster.Data;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.Service;

namespace AbantwanaWebMaster.BusinessLogic
{
    public class AssessmentBussiness
    {
        DataContext db = new DataContext();
        ClassroomBusiness cb = new ClassroomBusiness();
        //AssessmentBussiness ab = new AssessmentBussiness();
        YearBussiness yb = new YearBussiness();
        GradeBussiness gb = new GradeBussiness();
        termBussiness tb = new termBussiness();
        public List<Model.LearnerAssessment> GetAllLearnersByGrade(int classId)
        {

            //var classId = db.Subjects.Where(su => su.subjectId == sub).Select(l=>l.classRoomId).FirstOrDefault();
            var clLear = db.yearLearnerClassRooms.Where(k => k.classRoomId == classId).ToList();
            List<Model.LearnerAssessment> learnerAssessments = new List<Model.LearnerAssessment>();
            foreach (var item in clLear)
            {
                Model.LearnerAssessment learner = new Model.LearnerAssessment();
                learner.Name = GetName(item.learnerId);
                learner.Surname = GetSurName(item.learnerId);
                learner.learnerId = item.learnerId;
                learner.present = true;
                learner.classID = classId;
                learnerAssessments.Add(learner);

            }
            return learnerAssessments;

        }
        public List<Model.Assessment> getAssess()
        {

            using (var leaveRepo = new AssessmentRepository())
            {
                return leaveRepo.GetAll().Select(x => new Model.Assessment() { assessmentId = x.assessmentId, yearId = x.yearId, gradeId = x.gradeId, termId = x.termId, subjectId = x.subjectId, assessmentName = x.assessmentName, weightings = x.weightings, totMark = x.totMark, myClass = cb.GetClassrooms().Where(p => p.graddId == x.gradeId).ToList() }).ToList();
            }
        }
        public List<Model.Assessment> getAssoo(int subjectId, int gradeId, int yearId, int termId)
        {
            using (var leaveRepo = new AssessmentRepository())
            {
                return leaveRepo.GetAll().Where(p => p.subjectId == subjectId && p.gradeId == gradeId && p.yearId == yearId && p.termId == termId).Select(x => new Model.Assessment() { assessmentId = x.assessmentId, yearId = x.yearId, gradeId = x.gradeId, termId = x.termId, subjectId = x.subjectId, assessmentName = x.assessmentName, weightings = x.weightings, totMark = x.totMark, myClass = cb.GetClassrooms().Where(p => p.graddId == x.gradeId).ToList() }).ToList();
            }
        }
        public List<Model.YearLearnerGradeSubjectAssessment> getLearnerAssess()
        {

            using (var leaveRepo = new YearLearnerGradeSubjectAssessmentRepository())
            {
                return leaveRepo.GetAll().Select(x => new Model.YearLearnerGradeSubjectAssessment() { yearId = x.yearId, gradeId = x.gradeId, learnerId = x.learnerId, subjectId = x.subjectId, assessmentId = x.assessmentId, mark = x.mark }).ToList();
            }
        }
        public int getTot(int id)
        {
            using (var AssessmentRep = new AssessmentRepository())
            {
                return AssessmentRep.GetAll().Where(k => k.assessmentId == id).Select(l => l.totMark).FirstOrDefault();
            }
        }
        public List<Model.LearnerAssessment> GetAllLearnersByClassRoom(int yearId, int subjectId, int gradeId, int classRoomId, int assessmentId, int termId)
        {

            //var classId = db.Subjects.Where(su => su.subjectId == sub).Select(l=>l.classRoomId).FirstOrDefault();
            var clLear = db.yearLearnerClassRooms.Where(k => k.classRoomId == classRoomId&&k.yearId==yearId).ToList();
            List<Model.LearnerAssessment> learnerAssessments = new List<Model.LearnerAssessment>();
            if (clLear != null)
            {
                foreach (var item in clLear)
                {
                    Model.LearnerAssessment learner = new Model.LearnerAssessment();
                    learner.Name = item.learnerProfiles.lname;
                    learner.Surname = item.learnerProfiles.lsurname;
                    learner.learnerId = item.learnerId;
                    learner.present = true;
                    learner.assessmentId = assessmentId;
                    learner.classID = classRoomId;
                    learner.yearId = yearId;
                    learner.subjectId = subjectId;
                    learner.gradeid = gradeId;
                    learner.termId = termId;
                    learner.AssessmentMark = getLearnerAssess().Where(p => p.assessmentId == assessmentId && p.learnerId == item.learnerId).Select(l => l.mark).FirstOrDefault();
                    learnerAssessments.Add(learner);

                }
            }
            return learnerAssessments;

        }
        public void createAssessr(Model.Assessment x)
        {

            using (var leaveRepo = new AssessmentRepository())
            {
                if (x != null)
                {

                    var leaveCreate = new Data.Assessment() { yearId = x.yearId, gradeId = x.gradeId, termId = x.termId, subjectId = x.subjectId, assessmentName = x.assessmentName, weightings = x.weightings, totMark = x.totMark };
                    leaveRepo.Insert(leaveCreate);
                }
            }

        }
        public void createLeanerAssess(Model.YearLearnerGradeSubjectAssessment x)
        {

            using (var leaveRepo = new YearLearnerGradeSubjectAssessmentRepository())
            {
                if (x != null)
                {

                    var leaveCreate = new Data.YearLearnerGradeSubjectAssessment() { yearId = x.yearId, gradeId = x.gradeId, learnerId = x.learnerId, subjectId = x.subjectId, assessmentId = x.assessmentId, mark = x.mark };
                    leaveRepo.Insert(leaveCreate);
                }
            }

        }
        public void updateLeanerAssess(Model.YearLearnerGradeSubjectAssessment x)
        {

            using (var leaveRepo = new YearLearnerGradeSubjectAssessmentRepository())
            {
                if (x != null)
                {

                    var leaveCreate = db.yearLearnerGradeSubjectAssessments.Where(l => l.assessmentId == x.assessmentId).FirstOrDefault();
                    leaveCreate.mark = x.mark;
                    db.Entry(leaveCreate).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

        }

        public void updateAssess(Model.Assessment x)
        {

            using (var leaveRepo = new AssessmentRepository())
            {
                if (x != null)
                {

                    var leaveCreate = db.Assessments.Where(p=>p.assessmentId==x.assessmentId).FirstOrDefault();
                    leaveCreate.yearId = x.yearId;
                    leaveCreate.gradeId = x.gradeId;
                    leaveCreate.termId = x.termId;
                    leaveCreate.subjectId = x.subjectId;
                    leaveCreate.assessmentName = x.assessmentName;
                    leaveCreate.weightings = x.weightings;
                    leaveCreate.totMark = x.totMark;
                    //leaveCreate = new Data.Assessment() { assessmentId = x.assessmentId, yearId = x.yearId, gradeId = x.gradeId, termId = x.termId, subjectId = x.subjectId, assessmentName = x.assessmentName, weightings = x.weightings, totMark = x.totMark };

                    db.Entry(leaveCreate).State = EntityState.Modified;
                    db.SaveChanges();
                    //leaveRepo.Update(leaveCreate);
                }
            }

        }
        public List<Model.learnerReport> GetLearnerReport(int Id, int TermId, int grId, int yearId)
        {
            List<Model.learnerReport> learnerReports = new List<learnerReport>();

            List<Model.learnerSubject> learnersubList = new List<learnerSubject>();
            var learn = db.learnerProfiles.Where(l => l.learnerId == Id).FirstOrDefault();
            var subjects = db.gradeSubjects.Where(k => k.gradeId == grId).ToList();
            learnerReport learnerR = new learnerReport();
            if (subjects != null)
            {
                foreach (var sub in subjects)
                {
                    learnerSubject subject = new learnerSubject();
                    var assSub = db.Assessments.Where(s => s.subjectId == sub.subjectId && s.termId == TermId && s.gradeId == grId && s.yearId == yearId).ToList();
                    var lMark = 0.0;
                    ///var ltotMark = 0.0;
                    var totGradeMark = 0.0;
                    var totsumMark = 0.0;
                    var totNumL = 0.0;
                    var subAv = 0.0;
                    var assAv = 0.0;
                    if (assSub != null)
                    {
                        foreach (var lass in assSub)
                        {
                            try
                            {
                                totNumL = db.yearLearnerGradeSubjectAssessments.Where(l => l.assessmentId == lass.assessmentId&&l.yearId==yearId).Count();
                                totGradeMark = db.yearLearnerGradeSubjectAssessments.Where(l => l.assessmentId == lass.assessmentId).Select(k => k.mark).Sum();

                                //assessment Average
                                assAv = ((totGradeMark / ((double)lass.totMark * (double)totNumL))) * (double)lass.weightings;
                                //subject Average
                                subAv = subAv + assAv;
                                //Learner's Assesment Mark
                                lMark = db.yearLearnerGradeSubjectAssessments.Where(l => l.assessmentId == lass.assessmentId && l.learnerId == Id).Select(k => k.mark).FirstOrDefault();

                                //Learner's Subject Mark
                                totsumMark = totsumMark + ((lMark /(double) lass.totMark) * (double)lass.weightings);
                            }
                            catch { }

                        }
                    }
                    subject.mark = (int)totsumMark;
                    subject.Name = sub.subject.subjectName;
                    subject.average = (int)subAv;

                    if (subject.mark >= 80 && subject.mark <= 100)
                    {
                        subject.comment = "Excellent";
                    }
                    if (subject.mark >= 70 && subject.mark <= 79)
                    {
                        subject.comment = "Good";

                    }
                    if (subject.mark >= 60 && subject.mark <= 69)
                    {
                        subject.comment = "Satisfactory";

                    }
                    if (subject.mark >= 50 && subject.mark <= 59)
                    {
                        subject.comment = "Adequate";

                    }
                    if (subject.mark >= 40 && subject.mark <= 49)
                    {
                        subject.comment = "Poor";

                    }
                    if (subject.mark <= 39)
                    {
                        subject.comment = "Not Performed";

                    }
                    if (subject.mark < sub.requirement)
                    {
                        learnerR.results = "Failed";
                    }

                    learnersubList.Add(subject);
                }
            }
            if (learnerR.results == null)
            {
                learnerR.results = "Passed";
            }
            learnerR.year = yb.getYear().Where(l => l.yearId == yearId).Select(l => l.year).FirstOrDefault().ToString();
            int classId = cb.GetYearLearnerClassrooms().Where(p => p.yearId == yearId && p.learnerId == Id).Select(k => k.classRoomId).FirstOrDefault();
            int staff = db.classRooms.Where(p=>p.classRoomId==classId).Select(d=>d.staffId).FirstOrDefault();
            var loow = db.staffMembers.Where(p=>p.staffMemberId==staff).Select(d=>new { d.StaffMemberSurname, d.StaffMemberName }).FirstOrDefault();
            learnerR.teacher = loow.StaffMemberName + loow.StaffMemberSurname;
            learnerR.grade = learn.grade;
            learnerR.learnerId = learn.lidnumber;
            learnerR.learnerSubjects = learnersubList;
            learnerR.learnerName = learn.lname;
            learnerR.daysAbseent = db.attendances.Where(k => k.learnerId == learn.learnerId && k.present == false).Count();
            learnerR.termNumber = db.terms.Where(l => l.termId == TermId).Select(k => k.name).FirstOrDefault();
            if (learnerR.results == "Passed" && learnerR.termNumber == "4")
            {
                learnerR.results = "Promoted";
            }
            learnerReports.Add(learnerR);
            return learnerReports;
        }
        public string GetName(int? id)
        {
            var name = db.learnerProfiles.Where(l => l.learnerId == id).Select(l => l.lname).FirstOrDefault();
            return name;
        }
        public string GetSurName(int? id)
        {
            var name = db.learnerProfiles.Where(l => l.learnerId == id).Select(l => l.lsurname).FirstOrDefault();
            return name;
        }
        
        public List<Model.subjectReport> GetSubjectReport(int TermId, int grId, int yearId)
        {
            //List<Model.learnerReport> learnerReports = new List<learnerReport>();
            List<Model.subjectReport> learnerRep = new List<subjectReport>();

            List<Model.learnerSubject> learnersubList = new List<learnerSubject>();
            //var learn = db.learnerProfiles.Where(l => l.learnerId == Id).FirstOrDefault();
            var subjects = db.gradeSubjects.Where(k => k.gradeId == grId).ToList();
            learnerReport learnerR = new learnerReport();
            learnerMark learnerMark = new learnerMark();
            if (subjects != null)
            {
                foreach (var sub in subjects)
                {
                    subjectReport report = new subjectReport();
                    report.grade = gb.getGrade().Where(o => o.gradeId == grId).Select(l => l.gradeName).FirstOrDefault();
                    report.name = sub.subject.subjectName;
                    report.year = yb.getYear().Where(o => o.yearId == yearId).Select(l => l.year).FirstOrDefault().ToString();
                    report.termNumber = tb.getTerm().Where(o => o.termId == TermId).Select(p => p.name).FirstOrDefault();
                    report.requirement = sub.requirement.ToString();
                    //Assessments

                    var assss = db.Assessments.Where(l => l.termId == TermId && l.subjectId == sub.subjectId && l.gradeId == grId && l.yearId == yearId).ToList();
                    List<Model.Assessment> lop = new List<Model.Assessment>();
                    List<Model.learnerMark> lmas = new List<Model.learnerMark>();
                    int[] mar = new int[20];
                    int[] mar2 = new int[20];
                    int tot = 0;
                    List<int> marki = new List<int>();
                    foreach (var lo in assss)
                    {
                        Model.Assessment assessment100 = new Model.Assessment();
                        assessment100.assessmentName = lo.assessmentName;
                        assessment100.totMark = lo.totMark;
                        assessment100.weightings = lo.weightings;
                        report.total += lo.totMark;
                        report.wetotal += lo.weightings;
                        lop.Add(assessment100);
                      
                        var lm = db.yearLearnerGradeSubjectAssessments.Where(p => p.assessmentId == lo.assessmentId).ToList();
                        int p4 = 0;
                       
                        foreach (var kl in lm)
                        {
                                mar[p4] = kl.learnerId;
                                mar2[p4] = kl.assessmentId;
                                learnerMark.name = GetName(kl.learnerId);
                                
                             
                                foreach (var oop in lm.Where(s => s.learnerId == kl.learnerId&&s.assessmentId==kl.assessmentId))
                                {
                                    marki.Add(oop.mark);
                                    tot =tot+ (int)(((double)oop.mark / (double)lo.totMark) * (double)lo.weightings);
                                }
                                if (tot >= sub.requirement)
                                {
                                    report.result = "Pass";
                                }
                                else
                                {
                                    report.result = "Failed";
                                }
                                learnerMark.result = report.result;
                                learnerMark.total = tot;
                                //marki.Add(tot);
                                
                                learnerMark.mark = marki;
                        }

                       

                    }
                    lmas.Add(learnerMark);
                    report.learnerAssessment = lmas;
                    report.assess = lop;

                    learnerRep.Add(report);


                }


            }

            return learnerRep;

        }
    }
}
