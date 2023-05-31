using System.Collections.Generic;
using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    [SerializeField] private Button uiSpinButton;
    [SerializeField] private Button buttonClose;

    [SerializeField] private PickerWheel pickerWheel;
    [SerializeField] private GameObject wheelGacha;
    private List<WheelPiece> rewards;

    private void Start()
    {
        uiSpinButton.onClick.AddListener(() =>
        {
            uiSpinButton.gameObject.SetActive(false);

            pickerWheel.OnSpinEnd(wheelPiece =>
            {
                Debug.Log(
                    @" <b>Index:</b> " + wheelPiece.Index + "           <b>Label:</b> " + wheelPiece.Label
                    + "\n <b>Amount:</b> " + wheelPiece.Amount + "      <b>Chance:</b> " + wheelPiece.Chance + "%"
                );

                buttonClose.gameObject.SetActive(true);
                buttonClose.onClick.AddListener(() => { wheelGacha.gameObject.SetActive(false); });
            });

            pickerWheel.Spin();
        });
    }
}