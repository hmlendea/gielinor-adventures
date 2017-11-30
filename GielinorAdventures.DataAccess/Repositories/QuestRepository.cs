using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Quest repository implementation.
    /// </summary>
    public class QuestRepository
    {
        readonly XmlDatabase<QuestEntity> xmlDatabase;
        List<QuestEntity> questEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public QuestRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<QuestEntity>(fileName);
            questEntities = new List<QuestEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(questEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified quest.
        /// </summary>
        /// <param name="questEntity">Quest.</param>
        public void Add(QuestEntity questEntity)
        {
            LoadEntitiesIfNeeded();

            questEntities.Add(questEntity);
        }

        /// <summary>
        /// Get the quest with the specified identifier.
        /// </summary>
        /// <returns>The quest.</returns>
        /// <param name="id">Identifier.</param>
        public QuestEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            QuestEntity questEntity = questEntities.FirstOrDefault(x => x.Id == id);

            if (questEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(QuestEntity).Replace("Entity", ""));
            }

            return questEntity;
        }

        /// <summary>
        /// Gets all the quests.
        /// </summary>
        /// <returns>The quests</returns>
        public IEnumerable<QuestEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return questEntities;
        }

        /// <summary>
        /// Updates the specified quest.
        /// </summary>
        /// <param name="questEntity">Quest.</param>
        public void Update(QuestEntity questEntity)
        {
            LoadEntitiesIfNeeded();

            QuestEntity questEntityToUpdate = questEntities.FirstOrDefault(x => x.Id == questEntity.Id);

            if (questEntityToUpdate == null)
            {
                throw new EntityNotFoundException(questEntity.Id, nameof(QuestEntity).Replace("Entity", ""));
            }

            questEntityToUpdate.Name = questEntity.Name;

            xmlDatabase.SaveEntities(questEntities);
        }

        /// <summary>
        /// Removes the quest with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            questEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(questEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(QuestEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            questEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
