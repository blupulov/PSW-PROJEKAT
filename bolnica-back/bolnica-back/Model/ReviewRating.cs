using bolnica_back.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bolnica_back.Model
{
    public class ReviewRating
    {
        [Key]
        public long Id { get; set; }
        public string Comment { get; set; }
        public int Grade { get; set; }
        public long ReviewId { get; set; }
        [JsonIgnore]
        public Review Review { get; set; }

        public ReviewRating() { }

        public ReviewRating(RateReviewDTO dto)
        {
            ReviewId = dto.ReviewId;
            Comment = dto.Comment;
            Grade = dto.Grade;
        }
    }
}
