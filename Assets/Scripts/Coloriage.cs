using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Coloriage : Singleton<Coloriage>
{
    public List<GameObject> imagesToColor;
    public Color selectedColor;

    void Start()
    {
        Button[] colorButtons = GetComponentsInChildren<Button>();
        foreach (Button button in colorButtons)
        {
            button.onClick.AddListener(() => SelectColor(button.GetComponent<Image>().color));
        }
    }

    public void SelectColor(Color color)
    {
        selectedColor = color;
        print(selectedColor);
    }

    void Update()
    {
        // Vérifiez si l'utilisateur clique sur l'image
        if (Input.GetMouseButton(0))
        {
            // Lancez un rayon depuis la caméra pour détecter l'objet cliqué
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // Si l'objet cliqué est notre image, colorez-la
                if (imagesToColor.Contains(hit.collider.gameObject))
                {
                    // Obtenez la position du clic sur l'image
                    Image selectedImage = hit.collider.gameObject.GetComponent<Image>();
                    RectTransform imageRectTransform = selectedImage.rectTransform;
                    Vector2 localPoint;
                    if (
                        RectTransformUtility.ScreenPointToLocalPointInRectangle(
                            imageRectTransform,
                            Input.mousePosition,
                            null,
                            out localPoint
                        )
                    )
                    {
                        // Convertissez les coordonnées locales en coordonnées UV
                        float normalizedX =
                            (localPoint.x + imageRectTransform.rect.width * 0.5f)
                            / imageRectTransform.rect.width;
                        float normalizedY =
                            (localPoint.y + imageRectTransform.rect.height * 0.5f)
                            / imageRectTransform.rect.height;

                        // Appliquez la couleur à la texture de l'image
                        Texture2D texture = (Texture2D)selectedImage.sprite.texture;
                        texture.SetPixel(
                            (int)(normalizedX * texture.width),
                            (int)(normalizedY * texture.height),
                            selectedColor
                        );
                        texture.Apply();
                    }
                }
            }
        }
    }
}
