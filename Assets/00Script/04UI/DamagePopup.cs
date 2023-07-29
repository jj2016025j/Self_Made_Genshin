using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    public float disappearTime;
    public Vector3 offset;
    public Vector3 randomizeIntensity;
    private TextMesh textMesh;

    void Start()
    {
        textMesh = transform.GetComponent<TextMesh>();
        transform.localPosition += offset;
        transform.localPosition += new Vector3(Random.Range(-randomizeIntensity.x, randomizeIntensity.x),
                                               Random.Range(-randomizeIntensity.y, randomizeIntensity.y),
                                               Random.Range(-randomizeIntensity.z, randomizeIntensity.z));
        disappearTime = Time.time + disappearTime;
    }

    void Update()
    {
        if (Time.time > disappearTime)
        {
            // Fade out the damage amount here
            Color alpha = textMesh.color;
            alpha.a -= Time.deltaTime;
            textMesh.color = alpha;
            if (alpha.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Setup(int damageAmount)
    {
        textMesh.text = damageAmount.ToString();
    }
}
