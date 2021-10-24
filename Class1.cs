using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPZ_LB2
{
     class AutoShop : IComparable<AutoShop> 
     {
          int n_dep;
          int n_emp;
          string name;
          string adress;
          decimal avg_inc;
          decimal com_sal;
          decimal com_cost;
          int name_prod;
         public AutoShop(int n_dep, int n_emp, string name, string adress, decimal avg_inc, decimal com_sal, decimal com_cost, int name_prod)
         {
           this.n_dep = n_dep;
           this.n_emp = n_emp;
           this.name = name;
           this.adress = adress;
           this.avg_inc = avg_inc;
           this.com_sal = com_sal;
           this.com_cost = com_cost;
           this.name_prod = name_prod;
         }
        public int N_dep => n_dep;
        public int N_emp => n_emp;
        public string Name => name;
        public string Adress => adress;
        public decimal Avg_inc => avg_inc;
        public decimal Com_sal => com_sal;
        public decimal Com_cost => com_cost;
        public int Name_prod => name_prod;
        public void Add_employee()
        {
            n_emp++;
        }
        public void Rem_employee()
        {
            n_emp--;
        }
        public decimal Incom()
        {
            decimal income;
            income = avg_inc * 12;
            return income;
        }
        public static AutoShop operator ++(AutoShop op)
        {
            op.n_emp += 1;
            return op;
        }
        public static AutoShop operator --(AutoShop op)
        {
            op.n_emp -= 1;
            return op;
        }
        public  decimal Nalog()
        {
            decimal nalog;
            nalog = avg_inc* Convert.ToDecimal(0.17);
            return nalog;
        }
        public decimal this[int index]
        {
            get
            {
                if (index == 100) return this.avg_inc;
                if (index == 200) return this.com_sal;
                if (index == 300) return this.com_cost;
                else return -1;
            }
        }
        public int CompareTo(AutoShop o)
        {
          if (n_emp > o.n_emp)
              return 1;
          if (n_emp < o.n_emp)
              return -1;
          else
              return 0;
        }
       

     }
    
}
