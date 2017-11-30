using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Npc repository implementation.
    /// </summary>
    public class NpcRepository
    {
        readonly XmlDatabase<NpcEntity> xmlDatabase;
        List<NpcEntity> npcEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="NpcRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public NpcRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<NpcEntity>(fileName);
            npcEntities = new List<NpcEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(npcEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified npc.
        /// </summary>
        /// <param name="npcEntity">Npc.</param>
        public void Add(NpcEntity npcEntity)
        {
            LoadEntitiesIfNeeded();

            npcEntities.Add(npcEntity);
        }

        /// <summary>
        /// Get the npc with the specified identifier.
        /// </summary>
        /// <returns>The npc.</returns>
        /// <param name="id">Identifier.</param>
        public NpcEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            NpcEntity npcEntity = npcEntities.FirstOrDefault(x => x.Id == id);

            if (npcEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(NpcEntity).Replace("Entity", ""));
            }

            return npcEntity;
        }

        /// <summary>
        /// Gets all the npcs.
        /// </summary>
        /// <returns>The npcs</returns>
        public IEnumerable<NpcEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return npcEntities;
        }

        /// <summary>
        /// Updates the specified npc.
        /// </summary>
        /// <param name="npcEntity">Npc.</param>
        public void Update(NpcEntity npcEntity)
        {
            LoadEntitiesIfNeeded();

            NpcEntity npcEntityToUpdate = npcEntities.FirstOrDefault(x => x.Id == npcEntity.Id);

            if (npcEntityToUpdate == null)
            {
                throw new EntityNotFoundException(npcEntity.Id, nameof(NpcEntity).Replace("Entity", ""));
            }

            npcEntityToUpdate.Name = npcEntity.Name;
            npcEntityToUpdate.Description = npcEntity.Description;
            npcEntityToUpdate.Command = npcEntity.Command;
            npcEntityToUpdate.Sprites = npcEntity.Sprites;
            npcEntityToUpdate.HairColour = npcEntity.HairColour;
            npcEntityToUpdate.TopColour = npcEntity.TopColour;
            npcEntityToUpdate.TrousersColour = npcEntity.TrousersColour;
            npcEntityToUpdate.SkinColour = npcEntity.SkinColour;
            npcEntityToUpdate.Camera1 = npcEntity.Camera1;
            npcEntityToUpdate.Camera2 = npcEntity.Camera2;
            npcEntityToUpdate.WalkModel = npcEntity.WalkModel;
            npcEntityToUpdate.CombatModel = npcEntity.CombatModel;
            npcEntityToUpdate.CombatSprite = npcEntity.CombatSprite;
            npcEntityToUpdate.HealthLevel = npcEntity.HealthLevel;
            npcEntityToUpdate.AttackLevel = npcEntity.AttackLevel;
            npcEntityToUpdate.DefenceLevel = npcEntity.DefenceLevel;
            npcEntityToUpdate.StrengthLevel = npcEntity.StrengthLevel;
            npcEntityToUpdate.RespawnTime = npcEntity.RespawnTime;
            npcEntityToUpdate.IsAttackable = npcEntity.IsAttackable;
            npcEntityToUpdate.IsAggressive = npcEntity.IsAggressive;
            npcEntityToUpdate.Drops = npcEntity.Drops;

            xmlDatabase.SaveEntities(npcEntities);
        }

        /// <summary>
        /// Removes the npc with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            npcEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(npcEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(NpcEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            npcEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
