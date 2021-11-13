namespace MusicHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;

    public class Performer
    {
        public Performer()
        {
            this.PerformerSongs = new HashSet<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PERFORMER_FIRST_NAME)]
        public string FirstName  { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PERFORMER_LAST_NAME)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public decimal NetWorth  { get; set; }

        public ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
