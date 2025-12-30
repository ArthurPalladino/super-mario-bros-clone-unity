using UnityEngine;

[CreateAssetMenu(fileName = "Power", menuName = "Player/Power")]
public class Power : ScriptableObject
{
    //TODO Fazer mudanca de sprites e animacoes
    public AnimatorOverrideController animatorController;
    public Sprite idleSprite;
    public AudioClip changeSound;
    public int lifes;
    public int powerAnimatorNumber;
    public Power previousPower;
    
}
