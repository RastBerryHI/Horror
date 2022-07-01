using UnityEngine;

public class Appliable : MonoBehaviour
{
    [SerializeField] private Animation anim;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    public void Apply()
    {
        anim.Play();
    }
}
