using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChallengesProject.Helpers
{
    /// <summary>
    /// Attribute used to validate HttpPostedFileBase images
    /// </summary>
    public class ValidateImageAttribute : ValidationAttribute
    {
        /// <summary>
        /// Max size of the image in MB
        /// </summary>
        public int MaxSize { get; set; } = 1;

        /// <summary>
        /// List with allowed file extensions/formats
        /// </summary>
        public List<ImageFormat> AllowedExtensions { get; set; } = new List<ImageFormat>() { ImageFormat.Png, ImageFormat.Jpeg };

        public new string ErrorMessage { get; set; } = "The file must be less than {0} MB.";

        public ValidateImageAttribute() : base()
        {
        }

        public ValidateImageAttribute(int maxSize = 1) : base()
        {
            MaxSize = maxSize;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxSize">The maximum size of the file in MB</param>
        /// <param name="errorMessage">The error message. It could has a placeholder for the maximum size value. Ex: "File is larger than {0}.".</param>
        public ValidateImageAttribute(
            int maxSize = 1,
            string errorMessage = null) : base()
        {
            if (errorMessage != null)
            {
                ErrorMessage = errorMessage;
            }
            MaxSize = maxSize;
        }

        public ValidateImageAttribute(
            List<ImageFormat> allowedExtensions,
            int maxSize = 1,             
            string errorMessage = null) : this(maxSize, errorMessage)
        {
            AllowedExtensions = allowedExtensions;
        }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }
            // Check file length
            if (file.ContentLength > MaxSize * 1024 * 1024)
            {
                return false;
            }

            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    return AllowedExtensions.Contains(img.RawFormat);
                }
            }
            catch { }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(ErrorMessage, MaxSize);
        }
    }
}
