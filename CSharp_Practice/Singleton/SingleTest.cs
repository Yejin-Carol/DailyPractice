using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singleton_0611
{
    class SingleTest
    {
        private static SingleTest inst;
        private int data;
        

        public SingleTest(Random r)
        {
            data = r.Next(1, 100);
        }
        public int getData() //인스턴스 메소드
        {
            return data;//인스턴스 개념 
        }

        public static SingleTest getInst(Random r) //클래스 메소드, 싱글톤이라는 개념임!
            //처음만들어진 객체를 계속 사용하는 것, 모든 객체 지향에서 공통으로 사용 가능 (언어와 상관없음)
        {
            if (inst == null)
            {
                inst = new SingleTest(r);
            }
            return inst;
        }

    }
}
