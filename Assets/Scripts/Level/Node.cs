using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Renderer))]
public class Node : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private Material hoverMaterial;

    private Renderer rend;
    private Material baseMaterial;
    private GameObject towerOnNode;

    void Start()
    {
        rend = GetComponent<Renderer>();
        baseMaterial = rend.material;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rend.material = hoverMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rend.material = baseMaterial;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (towerOnNode != null) 
            return;

        towerOnNode = BuildManager.Instance.GetTower(transform.position, transform.rotation);
    }
}
