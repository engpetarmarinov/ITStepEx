using System;
using ChallengesProject.Data;
using ChallengesProject.Models;
using System.IO;

namespace ChallengesProject.Services
{
    public class ChallengesService : BaseService<Challenge>
    {
        public ChallengesService(IChallengesData data) : base(data)
        {
        }
        
        public string GenerateImageName(string fileName)
        {
            // change file name with its extension
            return Guid.NewGuid().ToString() + Path.GetExtension(fileName);
        }

        public string GenerateSubfolderName(string text)
        {
            var subFolder = text.Substring(0, 8);
            return subFolder + Path.DirectorySeparatorChar;
        }
    }

}