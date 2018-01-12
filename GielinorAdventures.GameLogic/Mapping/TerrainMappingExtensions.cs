using System.Collections.Generic;
using System.Linq;

using NuciXNA.Primitives.Mapping;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// Texture mapping extensions for converting between entities and domain models.
    /// </summary>
    static class TerrainMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="textureEntity">Texture entity.</param>
        internal static Terrain ToDomainModel(this TerrainEntity textureEntity)
        {
            Terrain terrain = new Terrain
            {
                Id = textureEntity.Id,
                Name = textureEntity.Name,
                Description = textureEntity.Description,
                Colour = ColourTranslator.FromHexadecimal(textureEntity.ColourHexadecimal)
            };

            return terrain;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="terrain">Texture.</param>
        internal static TerrainEntity ToEntity(this Terrain terrain)
        {
            TerrainEntity textureEntity = new TerrainEntity
            {
                Id = terrain.Id,
                Name = terrain.Name,
                Description = terrain.Description,
                ColourHexadecimal = terrain.Colour.ToHexadecimal()
            };

            return textureEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="textureEntities">Texture entities.</param>
        internal static IEnumerable<Terrain> ToDomainModels(this IEnumerable<TerrainEntity> textureEntities)
        {
            IEnumerable<Terrain> textures = textureEntities.Select(textureEntity => textureEntity.ToDomainModel());

            return textures;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="textures">Textures.</param>
        internal static IEnumerable<TerrainEntity> ToEntities(this IEnumerable<Terrain> textures)
        {
            IEnumerable<TerrainEntity> textureEntities = textures.Select(terrain => terrain.ToEntity());

            return textureEntities;
        }
    }
}
