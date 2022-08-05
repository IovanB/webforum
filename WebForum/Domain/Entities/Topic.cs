using System;
using Domain.Validators;

namespace Domain.Entities

{
    public class Topic : Entity
    {
        //private DateTime? createdAt;

        public string Name{ get; private set; }
        public Guid CategoryId { get; private set; }
        public DateTime CreatedAt { get;  set; }
        //public DateTime? CreatedAt
        //{
        //    get { return createdAt; }
        //    set { createdAt = value == null ? DateTime.UtcNow : value; }
        //}
        public DateTime UpdatedAt { get; set; }
        public Topic(Guid id,string name, Guid categoryId)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            Validate(this,new TopicValidator());
        }
        public Topic()
        {

        }
    }
}
