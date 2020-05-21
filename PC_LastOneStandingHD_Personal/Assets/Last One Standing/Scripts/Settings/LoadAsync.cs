using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LoadAsync : MonoBehaviour
{
    private AsyncOperation asyncOperation;

    [SerializeField] internal bool isLoadStart;
    [SerializeField] internal bool isPanelBackgroundImage;

    [Header("Parameter's Progress")]
    [SerializeField] internal Slider sliderLoadAsyn;
    [Range(0, 100)] 
    [SerializeField] internal float howMuchIsTheProgress;
    [SerializeField] internal string nameTextProgress;
    [SerializeField] internal TextMeshProUGUI textInProgress;
    [SerializeField] internal TextMeshProUGUI textPhrasesRandom;
    [TextArea(0,50)]
    [SerializeField] internal string[] phrasesRandom;
    
    [Header("Panel Backgroun")]
    [SerializeField] internal GameObject panelLoadAsync;
    [SerializeField] internal Sprite[] backgroundLoadAsyn;



    private void Awake()
    {
        if (isPanelBackgroundImage)
        {
            panelLoadAsync.SetActive(false);
            panelLoadAsync.GetComponent<Image>().sprite = backgroundLoadAsyn[Random.Range(0, backgroundLoadAsyn.Length)]; 
        }

        textPhrasesRandom.text = phrasesRandom[Random.Range(0, phrasesRandom.Length)];

        if (isLoadStart)
            StartCoroutine(LoadScene("SceneLobby"));
    }

    public void LoadButton(string scene)
    {
        StartCoroutine(LoadScene(scene));
    }

    private IEnumerator LoadScene(string scene)
    {
        yield return null;

        asyncOperation = SceneManager.LoadSceneAsync(scene);

        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            if(isPanelBackgroundImage)
                panelLoadAsync.SetActive(true);
  
            textInProgress.text = nameTextProgress + (asyncOperation.progress * howMuchIsTheProgress) + "%";
            sliderLoadAsyn.value = asyncOperation.progress;
            asyncOperation.allowSceneActivation = true;

            yield return null;
        }
    }
}
