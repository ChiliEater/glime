using UnityEngine;

namespace CodeBrewery.Glime.Battle
{
    /// <summary>
    /// Represents an encounter.
    /// </summary>
    class EncounterManager : MonoBehaviour
    {
        Participant Player { get; set; }
        Enemy[] Enemies { get; set; }
    }
}
