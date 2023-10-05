using API_EXAM;
using API_EXAM.Interface;
using System;


namespace API_EXAM.Implementation
{
    public class SqlService : ISqlService
    {
      /*  public string GetQuestions(bool isCount, FilterQuestionVM model)
        {
            string result = "";
            string start = @"SELECT ";
            string count = @"count(*) as ""totalCount"" ";
            string variables = @"
               ID Id,
               TITLE Question,
               IS_ESSE Type,
               STATUS Status,
               CREATED_ON CreateOn,
               CREATED_BY CreateBy ";


            string main = @"from QUESTIONS ";
            string cases = "";
            string end = @"order by CREATED_ON desc OFFSET @skip ROWS FETCH NEXT @limit ROWS ONLY";

            filterQuestion(ref cases, model);



            if (!isCount)
            {
                result = start + variables + main + cases + end;
            }

            if (isCount)
            {
                result = start + count + main + cases;
            }



            return result;

        }

        void filterQuestion(ref string cases, FilterQuestionVM model)
        {

            if (model.CourseId != null)
            {
                if (cases == "")
                {
                    cases = " WHERE ";
                }
                else
                {
                    cases += " AND ";
                }
                cases += @" QUESTIONS.COURSE_ID = @CourseId ";
            }

            if (model.Question != null)
            {
                if (cases == "")
                {
                    cases = " WHERE ";
                }
                else
                {
                    cases += " AND ";
                }
                cases += @" QUESTIONS.TITLE like @Question ";
            }


            if (model.IsEsse != null)
            {
                if (cases == "")
                {
                    cases = " WHERE ";
                }
                else
                {
                    cases += " AND ";
                }
                cases += @" QUESTIONS.IS_ESSE = @IsEsse ";
            }
            if (model.Status != null)
            {
                if (cases == "")
                {
                    cases = " WHERE ";
                }
                else
                {
                    cases += " AND ";
                }
                cases += @" QUESTIONS.STATUS = @Status ";
            }
        }*/

    }
}
