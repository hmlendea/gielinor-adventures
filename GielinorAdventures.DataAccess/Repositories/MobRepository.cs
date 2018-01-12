using System.Linq;

using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using GielinorAdventures.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Mob repository implementation.
    /// </summary>
    public class MobRepository : XmlRepository<MobEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MobRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public MobRepository(string fileName) : base(fileName)
        {

        }
        
        /// <summary>
        /// Updates the specified mob.
        /// </summary>
        /// <param name="mobEntity">Mob.</param>
        public override void Update(MobEntity mobEntity)
        {
            LoadEntitiesIfNeeded();

            MobEntity mobEntityToUpdate = Entities.FirstOrDefault(x => x.Id == mobEntity.Id);

            if (mobEntityToUpdate == null)
            {
                throw new EntityNotFoundException(mobEntity.Id, nameof(MobEntity));
            }

            mobEntityToUpdate.Name = mobEntity.Name;
            mobEntityToUpdate.Description = mobEntity.Description;
            mobEntityToUpdate.Command = mobEntity.Command;

            mobEntityToUpdate.IsAttackable = mobEntity.IsAttackable;
            mobEntityToUpdate.IsAggressive = mobEntity.IsAggressive;

            mobEntityToUpdate.RespawnTime = mobEntity.RespawnTime;
            mobEntityToUpdate.CombatStyle = mobEntity.CombatStyle;
            mobEntityToUpdate.Drops = mobEntity.Drops;

            mobEntityToUpdate.AttackLevel = mobEntity.AttackLevel;
            mobEntityToUpdate.HitpointsLevel = mobEntity.HitpointsLevel;
            mobEntityToUpdate.StrengthLevel = mobEntity.StrengthLevel;
            mobEntityToUpdate.DefenceLevel = mobEntity.DefenceLevel;
            mobEntityToUpdate.RangedLevel = mobEntity.RangedLevel;
            mobEntityToUpdate.MagicLevel = mobEntity.MagicLevel;

            XmlFile.SaveEntities(Entities);
        }
    }
}
