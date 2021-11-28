using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graph : MonoBehaviour
{
    public CarController carController;
    public int i;

    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;

    // Start is called before the first frame update
    void Awake()
    {
        graphContainer = transform.Find("Graph").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void CreateCircle(Vector2 AnchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = AnchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

        Destroy(gameObject, 1);
    }

    void ShowGraph(float Value)
    {
        if (i == 120)
        {
            i = 0;
        }
        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;
        float yMax = 1f;
        float xSize = 10f;
        float xPosition = i * xSize;
        float yPosition = (Value / yMax) * graphHeight;
        CreateCircle(new Vector2(xPosition, yPosition));

        //graphContainer.anchoredPosition = new Vector2(graphContainer.anchoredPosition.x-1f, graphContainer.anchoredPosition.y);

        i += 1;
    }

    private void Update()
    {
        ShowGraph(carController.rearSlipLong);
    }

}
