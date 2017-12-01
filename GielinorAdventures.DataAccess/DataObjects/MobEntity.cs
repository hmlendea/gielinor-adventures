namespace GielinorAdventures.DataAccess.DataObjects
{
    public class MobEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>The command.</value>
        public string Command { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MobEntity"/> is attackable.
        /// </summary>
        /// <value><c>true</c> if it is attackable; otherwise, <c>false</c>.</value>
        public bool IsAttackable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MobEntity"/> is aggressive.
        /// </summary>
        /// <value><c>true</c> if it is aggressive; otherwise, <c>false</c>.</value>
        public bool IsAggressive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating how long it takes for this <see cref="MobEntity"/> to respawn.
        /// </summary>
        /// <value>The respawn time.</value>
        public int RespawnTime { get; set; }

        /// <summary>
        /// Gets or sets the combat style.
        /// </summary>
        /// <value>The combat style.</value>
        public string CombatStyle { get; set; }

        /// <summary>
        /// Gets or sets the drops.
        /// </summary>
        /// <value>The drops.</value>
        public ItemDropEntity[] Drops { get; set; }

        /// <summary>
        /// Gets or sets the attack level.
        /// </summary>
        /// <value>The attack level.</value>
        public int AttackLevel { get; set; }

        /// <summary>
        /// Gets or sets the hitpoints level.
        /// </summary>
        /// <value>The hitpoints level.</value>
        public int HitpointsLevel { get; set; }

        /// <summary>
        /// Gets or sets the strength level.
        /// </summary>
        /// <value>The strength level.</value>
        public int StrengthLevel { get; set; }

        /// <summary>
        /// Gets or sets the defence level.
        /// </summary>
        /// <value>The defence level.</value>
        public int DefenceLevel { get; set; }

        /// <summary>
        /// Gets or sets the ranged level.
        /// </summary>
        /// <value>The ranged level.</value>
        public int RangedLevel { get; set; }

        /// <summary>
        /// Gets or sets the magic level.
        /// </summary>
        /// <value>The magic level.</value>
        public int MagicLevel { get; set; }
    }
}
