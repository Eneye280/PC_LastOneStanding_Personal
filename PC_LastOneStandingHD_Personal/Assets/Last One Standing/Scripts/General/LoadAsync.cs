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
    internal string nameSceneForLoad;
    [SerializeField] internal bool isPanelBackgroundImage;

    [Header("Parameter's Progress")]
    [SerializeField] internal Image sliderLoadAsyn;
    [Range(-100, 100)] 
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
            nameSceneForLoad = "SceneSelecctionCharacter";
            if (isLoadStart)
                StartCoroutine(LoadScene(nameSceneForLoad));

            GameManager.instance.sOGameManager.isSceneSelectionPlayer = false;
            GameManager.instance.modeGame = ModeGame.selectionPlayer;
        }
        else if (!GameManager.instance.sOGameManager.isSceneSelectionPlayer)
        {
            nameSceneForLoad = "SceneLobby";
            if (isLoadStart)
                StartCoroutine(LoadScene(nameSceneForLoad));

            GameManager.instance.modeGame = ModeGame.lobby;
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
            if(isPanelBackgroundImage)
                panelLoadAsync.SetActive(true);
  
            textInProgress.text = asyncOperation.progress * (int)howMuchIsTheProgress + "%" ;
            sliderLoadAsyn.fillAmount = asyncOperation.progress;
            asyncOperation.allowSceneActivation = true;
            yield return null;
        }
    }
}
