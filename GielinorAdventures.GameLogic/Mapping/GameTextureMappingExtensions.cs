using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// Texture mapping extensions for converting between entities and domain models.
    /// </summary>
    static class GameTextureMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="textureEntity">Texture entity.</param>
        internal static GameTexture ToDomainModel(this GameTextureEntity textureEntity)
        {
            GameTexture texture = new GameTexture
            {
                Name = textureEntity.Name,
                SubName = textureEntity.SubName
            };

            return texture;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="texture">Texture.</param>
        internal static GameTextureEntity ToEntity(this GameTexture texture)
        {
            GameTextureEntity textureEntity = new GameTextureEntity
            {
                Name = texture.Name,
                SubName = texture.SubName
            };

            return textureEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="textureEntities">Texture entities.</param>
        internal static IEnumerable<GameTexture> ToDomainModels(this IEnumerable<GameTextureEntity> textureEntities)
        {
            IEnumerable<GameTexture> textures = textureEntities.Select(textureEntity => textureEntity.ToDomainModel());

            return textures;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="textures">Textures.</param>
        internal static IEnumerable<GameTextureEntity> ToEntities(this IEnumerable<GameTexture> textures)
        {
            IEnumerable<GameTextureEntity> textureEntities = textures.Select(texture => texture.ToEntity());

            return textureEntities;
        }
    }
}
