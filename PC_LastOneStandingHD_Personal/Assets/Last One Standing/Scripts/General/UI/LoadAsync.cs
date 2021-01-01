using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LoadAsync : MonoBehaviour
{
    public static LoadAsync instance;

    private AsyncOperation asyncOperation;

    [SerializeField] internal bool isLoadStart;
    [SerializeField] internal bool isPanelBackgroundImage;
    [SerializeField] internal GameObject canvasLoadAsyn;

    [Header("Parameter's Progress")]
    [SerializeField] internal Slider sliderLoadAsyn;
    [Range(-100, 100)] 
    [SerializeField] internal float howMuchIsTheProgress;
    [Range(0, 50)]
    [SerializeField] internal float numberMultiplicateLoadAsyn;

    [Space(15)]
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
        if (!instance)
            instance = FindObjectOfType<LoadAsync>();
        else
            Destroy(gameObject);

        if (isPanelBackgroundImage)
        {
            panelLoadAsync.SetActive(false);
            panelLoadAsync.GetComponent<Image>().sprite = backgroundLoadAsyn[Random.Range(0, backgroundLoadAsyn.Length)];
        }

        textPhrasesRandom.text = phrasesRandom[Random.Range(0, phrasesRandom.Length)];

        if (GameManager.instance.sOGameManager.isSceneSelectionPlayer)
        {
            if (isLoadStart)
                StartCoroutine(LoadScene("SceneSelectionPlayer"));

            GameManager.instance.modeGame = ModeGame.selectionPlayer;
            canvasLoadAsyn.SetActive(false);
        }
        else if (!GameManager.instance.sOGameManager.isSceneSelectionPlayer)
        {
            if (isLoadStart)
                StartCoroutine(LoadScene("SceneLobby"));

            GameManager.instance.modeGame = ModeGame.lobby;
            canvasLoadAsyn.SetActive(false);
        }
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
            if (isPanelBackgroundImage)
                panelLoadAsync.SetActive(true);

            textInProgress.text = asyncOperation.progress * (int)howMuchIsTheProgress + "%";
            sliderLoadAsyn.value = asyncOperation.progress;
            asyncOperation.allowSceneActivation = true;
            yield return null;
        } 
    }
}
