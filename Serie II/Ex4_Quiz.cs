using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public struct Qcm
    {
        public strign Question;
        public int Solution;
        publig string[] Answers;
        public int Weight;
    }

    public Qcm(string question, string[] answers, int solution, int weight)
    {
        question = question;
        Answers = answers;
        Weight = weignth;
        solution = solution;
    }

    public class Quiz
    {
        public void AskQuestions(Qcm[] qcms)
        {
            //TODO
        }

        public int AskQuestion(Qcm qcm)
        {
            //TODO
            return -1;
        }

        public bool QcmValidity(Qcm qcm)
        {
            //TODO
            return false;
        }
    }
}
