using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuilderPattern.Core
{
    [Table("ComputeParts")]
    public class ComputePart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string UseType { get; set; }

        [Required]
        [StringLength(20)]
        public string Part { get; set; }

        [Required]
        [StringLength(50)]
        public string PartCode { get; set; }
    }
}
