using System.Collections.Generic;
using System.IO;
using System.Linq;

using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using GielinorAdventures.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Animation repository implementation.
    /// </summary>
    public class AnimationRepository : XmlRepository<AnimationEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnimationRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public AnimationRepository(string fileName) : base(fileName)
        {

        }

        /// <summary>
        /// Updates the specified animation.
        /// </summary>
        /// <param name="animationEntity">Animation.</param>
        public override void Update(AnimationEntity animationEntity)
        {
            LoadEntitiesIfNeeded();

            AnimationEntity animationEntityToUpdate = Entities.FirstOrDefault(x => x.Id == animationEntity.Id);

            if (animationEntityToUpdate == null)
            {
                throw new EntityNotFoundException(animationEntity.Id, nameof(AnimationEntity));
            }

            animationEntityToUpdate.Name = animationEntity.Name;
            animationEntityToUpdate.CharacterColour = animationEntity.CharacterColour;
            animationEntityToUpdate.GenderModel = animationEntity.GenderModel;
            animationEntityToUpdate.HasA = animationEntity.HasA;
            animationEntityToUpdate.HasF = animationEntity.HasF;
            animationEntityToUpdate.Number = animationEntity.Number;

            XmlFile.SaveEntities(Entities);
        }
    }
}
