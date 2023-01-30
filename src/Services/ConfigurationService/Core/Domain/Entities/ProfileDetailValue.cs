using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ProfileDetailValue : EntityBase
{
    /// <summary>
    /// ProfileCommon: Possible values like APPEARANCES, DOCUMENT_HASHING_ALGORITHM, PDF_SIGNATURE_TYPE etc
    /// </summary>
    public string AttributeName { get; set; }
    public string AttributeValue { get; set; }
}
