using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltipUI : MonoBehaviour
{
    [SerializeField]
    private Text _titleText;

    [SerializeField]
    private GameObject go_base;

    [SerializeField]
    private Text _contentText;

    private RectTransform _rt;
    private CanvasScaler _canvasScaler;

    private void Awake()
    {
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    public void ShowToolTip(Item _item, Vector3 _pos)
    {
        go_base.gameObject.SetActive(true);
        
        transform.position = _pos;

        _titleText.text = _item.name;
       _contentText.text = _item.itemdescription;

    }

    public void HideToolTip()
    {
        go_base.gameObject.SetActive(false);
    }
    private void Init()
    {
        TryGetComponent(out _rt);
        _rt.pivot = new Vector2(01, 1f);
        _canvasScaler = GetComponentInParent<CanvasScaler>();

        DisableAllChildrenRayCastTarget(transform);
    }

    private void DisableAllChildrenRayCastTarget(Transform tr)
    {
        tr.TryGetComponent(out Graphic gr);
        if (gr != null)
            gr.raycastTarget = false;

        int childcount = tr.childCount;
        if (childcount == 0) return;

        for(int i = 0; i < childcount; i++)
        {
            DisableAllChildrenRayCastTarget(_rt.GetChild(i));
        }
    }


    public void SetRectPosition(RectTransform slotRect)
    {
        //캔버스 스케일러에 따른 해상도 대응
        float wRatio = Screen.width / _canvasScaler.referenceResolution.x;
        float hRatio = Screen.height / _canvasScaler.referenceResolution.y;

        float ratio = wRatio * (1f - _canvasScaler.matchWidthOrHeight) +
            hRatio * (_canvasScaler.matchWidthOrHeight);

        float slotWidth = slotRect.rect.width * ratio;
        float slotHeight = slotRect.rect.height * ratio;

        //툴팁 초기 위치 (슬롯 우하단)설정
        _rt.position = slotRect.position + new Vector3(slotWidth, - slotWidth);
        Vector2 pos = _rt.position;

        //툴팁의 크기
        float width = _rt.rect.width * ratio;
        float height = _rt.rect.height * ratio;

        //우측, 하단이 잘렸는지 여부
        bool rightTruncated = pos.x + width > Screen.width;
        bool botoomTruncated = pos.y - height < 0f;

        ref bool R = ref rightTruncated;
        ref bool B = ref botoomTruncated;

        if(R && !B)
        {
            _rt.position = new Vector2(pos.x - width - slotWidth, pos.y);
        }

        else if(!R && B)
        {
            _rt.position = new Vector2(pos.x, pos.y + height + slotHeight);
        }

        else if(R && B)
        {
            _rt.position = new Vector2(pos.x - width - slotWidth, pos.y + height + slotHeight);
        }
    }
}
