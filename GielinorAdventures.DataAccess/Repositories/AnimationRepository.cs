using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Animation repository implementation.
    /// </summary>
    public class AnimationRepository
    {
        readonly XmlDatabase<AnimationEntity> xmlDatabase;
        List<AnimationEntity> animationEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimationRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public AnimationRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<AnimationEntity>(fileName);
            animationEntities = new List<AnimationEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(animationEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified animation.
        /// </summary>
        /// <param name="animationEntity">Animation.</param>
        public void Add(AnimationEntity animationEntity)
        {
            LoadEntitiesIfNeeded();

            animationEntities.Add(animationEntity);
        }

        /// <summary>
        /// Get the animation with the specified identifier.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="id">Identifier.</param>
        public AnimationEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            AnimationEntity animationEntity = animationEntities.FirstOrDefault(x => x.Id == id);

            if (animationEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(AnimationEntity).Replace("Entity", ""));
            }

            return animationEntity;
        }

        /// <summary>
        /// Gets all the animations.
        /// </summary>
        /// <returns>The animations</returns>
        public IEnumerable<AnimationEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return animationEntities;
        }

        /// <summary>
        /// Updates the specified animation.
        /// </summary>
        /// <param name="animationEntity">Animation.</param>
        public void Update(AnimationEntity animationEntity)
        {
            LoadEntitiesIfNeeded();

            AnimationEntity animationEntityToUpdate = animationEntities.FirstOrDefault(x => x.Id == animationEntity.Id);

            if (animationEntityToUpdate == null)
            {
                throw new EntityNotFoundException(animationEntity.Id, nameof(AnimationEntity).Replace("Entity", ""));
            }

            animationEntityToUpdate.Name = animationEntity.Name;
            animationEntityToUpdate.CharacterColour = animationEntity.CharacterColour;
            animationEntityToUpdate.GenderModel = animationEntity.GenderModel;
            animationEntityToUpdate.HasA = animationEntity.HasA;
            animationEntityToUpdate.HasF = animationEntity.HasF;
            animationEntityToUpdate.Number = animationEntity.Number;

            xmlDatabase.SaveEntities(animationEntities);
        }

        /// <summary>
        /// Removes the animation with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            animationEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(animationEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(AnimationEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            animationEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
