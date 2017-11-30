using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// Animation mapping extensions for converting between entities and domain models.
    /// </summary>
    static class AnimationMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="animationEntity">Animation entity.</param>
        internal static Animation ToDomainModel(this AnimationEntity animationEntity)
        {
            Animation animation = new Animation
            {
                Name = animationEntity.Name,
                CharacterColour = animationEntity.CharacterColour,
                GenderModel = animationEntity.GenderModel,
                HasA = animationEntity.HasA,
                HasF = animationEntity.HasF,
                Number = animationEntity.Number
            };

            return animation;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="animation">Animation.</param>
        internal static AnimationEntity ToEntity(this Animation animation)
        {
            AnimationEntity animationEntity = new AnimationEntity
            {
                Name = animation.Name,
                CharacterColour = animation.CharacterColour,
                GenderModel = animation.GenderModel,
                HasA = animation.HasA,
                HasF = animation.HasF,
                Number = animation.Number
            };

            return animationEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="animationEntities">Animation entities.</param>
        internal static IEnumerable<Animation> ToDomainModels(this IEnumerable<AnimationEntity> animationEntities)
        {
            IEnumerable<Animation> animations = animationEntities.Select(animationEntity => animationEntity.ToDomainModel());

            return animations;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="animations">Animations.</param>
        internal static IEnumerable<AnimationEntity> ToEntities(this IEnumerable<Animation> animations)
        {
            IEnumerable<AnimationEntity> animationEntities = animations.Select(animation => animation.ToEntity());

            return animationEntities;
        }
    }
}
