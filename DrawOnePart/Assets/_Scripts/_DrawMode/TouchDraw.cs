using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchDraw : MonoBehaviour
{
    public Coroutine drawing;
    public GameObject linePrefab;
    public ParticleSystem lineParticle;
    public AudioClip drawingSound;
    private Vector3 lineStartPos = new Vector3(0, 0, 0);


    private void Update()
    {
        lineParticle.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            SoundManager.Instance.drawingSoundSource.Stop();
        }

        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;
            if (EventSystem.current.IsPointerOverGameObject(id))
            {
                SoundManager.Instance.drawingSoundSource.Stop();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartLine();
            lineParticle.gameObject.SetActive(true);
            lineParticle.Play();
            PlayDrawSound();
        }

        if (Input.GetMouseButtonUp(0))
        {
            FinishLine();
            lineParticle.gameObject.SetActive(false);
        }
    }


    private void PlayDrawSound()
    {
        if (SoundManager.Instance.drawingSoundSource.isPlaying)
        {
            SoundManager.Instance.drawingSoundSource.Pause();
        }
        else
        {
            SoundManager.Instance.drawingSoundSource.PlayOneShot(drawingSound);
        }
    }

    private void StartLine()
    {
        if (drawing != null)
        {
            StopCoroutine(drawing);
        }

        drawing = StartCoroutine(DrawLine());
    }

    private void FinishLine()
    {
        StopCoroutine(drawing);
    }

    IEnumerator DrawLine()
    {
        GameObject newGameObject = Instantiate(linePrefab, lineStartPos, Quaternion.identity);
        LineRenderer line = newGameObject.GetComponent<LineRenderer>();
        line.positionCount = 0;
        while (true)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, position);
            yield return null;
        }
    }
}