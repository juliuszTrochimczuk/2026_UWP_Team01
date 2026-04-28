using Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Renderer))]
public class Node : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private Material hoverMaterial;
    [SerializeField] private UnityEvent<Node> onNodeClicked;
    public void OnNodeClickedAddListener(UnityAction<Node> action) => onNodeClicked.AddListener(action);
    public void OnNodeClickedRemoveListener(UnityAction<Node> action) => onNodeClicked.RemoveListener(action);

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
        onNodeClicked.Invoke(this);

        if (towerOnNode != null) 
            return;

        towerOnNode = InstanceManager.Instance.GetTower(transform.position, transform.rotation);
    }
}
