using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Topic 
    {
        public int Id { get; set; }

        [Required]
        public string Name{ get; private set; }
        [Required]
        public int CategoryId { get; private set; }
        
        public Topic(int id, string name, int categoryId)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
        }


    }
}
