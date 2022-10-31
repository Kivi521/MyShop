using System;
namespace OrderManagementSystemNew.Data.Entity
{
    public class OrderState
    {
        public string _olderHeader;
        public string state { get; set; }
        public virtual void Complete()
        {

        }
        public virtual void Reject()
        {

        }
        public virtual void Submit()
        {

        }
    }
}
