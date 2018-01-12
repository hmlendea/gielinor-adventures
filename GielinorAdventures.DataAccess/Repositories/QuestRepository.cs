using System.Linq;

using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using GielinorAdventures.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Quest repository implementation.
    /// </summary>
    public class QuestRepository : XmlRepository<QuestEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public QuestRepository(string fileName) : base(fileName)
        {

        }
        
        /// <summary>
        /// Updates the specified quest.
        /// </summary>
        /// <param name="questEntity">Quest.</param>
        public override void Update(QuestEntity questEntity)
        {
            LoadEntitiesIfNeeded();

            QuestEntity questEntityToUpdate = Entities.FirstOrDefault(x => x.Id == questEntity.Id);

            if (questEntityToUpdate == null)
            {
                throw new EntityNotFoundException(questEntity.Id, nameof(QuestEntity));
            }

            questEntityToUpdate.Name = questEntity.Name;

            XmlFile.SaveEntities(Entities);
        }
    }
}
