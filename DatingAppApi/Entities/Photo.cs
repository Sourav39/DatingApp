using System.ComponentModel.DataAnnotations.Schema;

namespace DatingAppApi.Entities
{
    [Table("Photos")]  //Will Name the table as Photos.
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }

        //Navigational property for creating relationship between AppUser and Photos.
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}