using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
namespace Tests
{
  public class TestScript
{
    [OneTimeSetUp]
    public void LoadScene()
    {
      SceneManager.LoadScene("GameTitle");
    }
/*
    [Test]
    public void 메인화면_UI출력()
    {
      SceneManager.LoadScene("GameTitle");
      Scene scene = SceneManager.GetActiveScene();
      Assert.AreEqual("GameTitle",scene.name);
      //var obj = GameObject.Find("Canvas");
      //Assert.IsTrue(obj.GetComponent<Title>().nameCheck());
    }

    public void 메인화면_스테이지진입()
    {
      Title title;
      SceneManager.LoadScene("GameTitle");
      title = GameObject.Find("Scene_main").GetComponent<Title>();
      // KeyDownEvent(anyInput) 입력 전달
      Scene scene = SceneManager.GetActiveScene();
      Assert.AreEqual("StageSelect",scene.name);
    }

    public void 메인화면_게임종료()
    {
      SceneManager.LoadScene("GameTitle");
      var title = GameObject.Find("Scene_main").GetComponent<Title>();
      // KeyDownEvent(ESC);
      Assert.IsTrue(title.OnApplicationQuit());
    }

    public void 메인화면_음악재생()
    {
      //오브젝트 오디오클립 넣은상태
      var obj = GameObject.Find("SoundManager").GetComponent<AudioSource>();
      Assert.IsTrue(obj.isPlaying);
    }

    public void 메인화면_음악반복재생()
    {
      var obj = GameObject.Find("SoundManager").GetComponent<AudioSource>();
      Assert.IsTrue(obj.loop);
    }

    public void 메인화면_클릭효과음()
    {
      var obj = GameObject.Find("Scene_main").GetComponent<Title>();
      Assert.IsTrue(obj.SoundPlay());
    }

    public void 스테이지창_UI출력()
    {
      SceneManager.LoadScene("StageSelect");
      Scene scene = SceneManager.GetActiveScene();
      Assert.AreEqual("StageSelect",scene.name);
      //var obj = GameObject.Find("Canvas");
      //Assert.IsTrue(obj.GetComponent<Title>().nameCheck());
    }
    public void 스테이지창_옵션창진입()
    {
      var obj = GameObject.Find("Button_Option").GetComponent<스크립트이름>();
      obj.LoadOptionScene();      입력 들어오면 옵션창으로 이동하는 함수
      Scene scene = SceneManager.GetActiveScene();
      Assert.AreEqual("GameOption",scene.name);
    }
    public void 스테이지창_1stage진입()
    {
      SceneManager.LoadScene("GameSelect");
      var obj = GameObject.Find("Button_Stage1").GetComponent<스크립트이름>();
      obj.LoadStage1();
      Scene scene = SceneManager.GetActiveScene();
      Assert.AreEqual("Stage1",scene.name);
    }

    public void 스테이지창_2stage진입()
    {
      SceneManager.LoadScene("GameSelect");
      var obj = GameObject.Find("Button_Stage2").GetComponent<스크립트이름>();
      obj.LoadStage2();
      Scene scene = SceneManager.GetActiveScene();
      Assert.AreEqual("Stage2",scene.name);
    }

    public void 스테이지창_3stage진입()
    {
      SceneManager.LoadScene("GameSelect");
      var obj = GameObject.Find("Button_Stage3").GetComponent<스크립트이름>();
      obj.LoadStage3();
      Scene scene = SceneManager.GetActiveScene();
      Assert.AreEqual("Stage3",scene.name);
    }

    public void 스테이지창_4stage진입()
    {
      SceneManager.LoadScene("GameSelect");
      var obj = GameObject.Find("Button_Stage4").GetComponent<스크립트이름>();
      obj.LoadStage4();
      Scene scene = SceneManager.GetActiveScene();
      Assert.AreEqual("Stage4",scene.name);
    }

    public void 스테이지창_메인복귀()
    {
      SceneManager.LoadScene("GameSelect");
      var obj = GameObject.Find("Button_Quit").GetComponent<스크립트이름>();
      obj.LoadTitleScene();      입력 들어오면 옵션창으로 이동하는 함수
      Scene scene = SceneManager.GetActiveScene();
      Assert.AreEqual("GameTitle",scene.name);
    }

    public void 스테이지창_음악재생()
    {
      var obj = GameObject.Find("SoundManager").GetComponent<AudioSource>();
      Assert.IsTrue(obj.isPlaying);
    }

    public void 스테이지창_메인음악계속재생()
    {
      //메인화면 음악 오브젝트에 dontdestroyonload
      SceneManager.LoadScene("GameTitle");
      var obj1 = GameObject.Find("Scene_main").GetComponent<Title>();
      //title.ButtonInput();      입력 들어오면 화면 이동하는 함수
      var src = obj.GetComponent<AudioSource>();
      Assert.IsTrue(src.isPlaying);
    }

    public void 스테이지창_클릭효과음()
    {
      var obj1 = GameObject.Find("Button_left").GetComponent<AudioSource>();
      var obj2 = GameObject.Find("Button_right").GetComponent<AudioSource>();
      obj1.PlayOnClick();     클릭 시 사운드 재생 함수
      Assert.IsTrue(obj1.isPlaying);
      obj2.PlayOnClick();
      Assert.IsTrue(obj2.isPlaying);
    }

    public void 브리핑_UI출력()
    {
      SceneManager.LoadScene("Briefing");
      Scene scene = SceneManager.GetActiveScene();
      Assert.AreEqual("Briefing",scene.name);
      //var obj = GameObject.Find("Canvas");
      //Assert.IsTrue(obj.GetComponent<Title>().nameCheck());
    }

    public void 브리핑_situation출력()  // 스테이지별로 추가필요
    {
      var obj = GameObject.Find("Button_situation").GetComponent<스크립트이름>();
      obj.LoadSituation();      입력 들어오면 상황설명 이미지 활성화하는 함수
      var obj2 = GameObject.Find("img_situation");
      Assert.IsTrue(obj2.activeSelf);
    }

    public void 브리핑_objective출력()
    {
      var obj = GameObject.Find("Button_objective").GetComponent<스크립트이름>();
      obj.LoadObjective();      입력 들어오면 상황설명 이미지 활성화하는 함수
      var obj2 = GameObject.Find("img_objective");
      Assert.IsTrue(obj2.activeSelf);
    }

    public void 브리핑_map출력()
    {
      var obj = GameObject.Find("Button_map").GetComponent<스크립트이름>();
      obj.LoadMap();      입력 들어오면 상황설명 이미지 활성화하는 함수
      var obj2 = GameObject.Find("img_map");
      Assert.IsTrue(obj2.activeSelf);
    }

    public void 브리핑_스테이지창진입()
    {
      var obj = GameObject.Find("Button_Stage").GetComponent<스크립트이름>();
      obj.LoadSelectScene();      입력 들어오면 옵션창으로 이동하는 함수
      Scene scene = SceneManager.GetActiveScene();
      Assert.AreEqual("GameSelect",scene.name);
    }

    public void 브리핑_게임시작()
    {
      var obj = GameObject.Find("Scene_briefing").GetComponent<스크립트이름>();
      string num = obj.stagenum();      브리핑 씬이 갖고있는 현재 스테이지 숫자값
      obj.gameStart();          // 게임 시작하는 함수(스테이지1~4 씬 진입)
      Scene scene = SceneManager.GetActiveScene();
      Assert.AreEqual("Stage" + num ,scene.name);
    }

    public void 브리핑_메인화면진입()
    {
      var obj = GameObject.Find("Button_Title").GetComponent<스크립트이름>();
      obj.LoadTitleScene();      입력 들어오면 옵션창으로 이동하는 함수
      Scene scene = SceneManager.GetActiveScene();
      Assert.AreEqual("GameTitle",scene.name);
    }

    public void 브리핑_난이도변경()
    {
      var obj = GameObject.Find("Button_Difficulty").GetComponent<스크립트이름>();
      obj.ButtonPushed();      입력 들어오면 난이도 변경하는 함수.
      bool isHard = obj.isHard;        // 0 = easy, 1 = hard. 초기값은 0
      Assert.IsTrue(isHard);
      obj.ButtonPushed();
      Assert.IsTrue(!isHard);
    }

    public void 브리핑_이전결과출력()
    {

    }
    public void 브리핑_등급갱신()
    {

    }
    public void 옵션창_UI출력()
    {
      SceneManager.LoadScene("GameOption");
      Scene scene = SceneManager.GetActiveScene();
      Assert.AreEqual("GameOption",scene.name);
      //var obj = GameObject.Find("Canvas");
      //Assert.IsTrue(obj.GetComponent<Title>().nameCheck());
    }
    public void 옵션창_버튼상호작용()
    {

    }
    public void 옵션창_밝기조절()
    {

    }
    public void 옵션창_마우스감도()
    {

    }
    public void 옵션창_소리크기()
    {

    }
    public void 옵션창_메인화면진입()
    {
      var obj = GameObject.Find("Button_Title").GetComponent<스크립트이름>();
      obj.LoadTitleScene();      입력 들어오면 옵션창으로 이동하는 함수
      Scene scene = SceneManager.GetActiveScene();
      Assert.AreEqual("GameTitle",scene.name);
    }
    public void 옵션창_메인음악계속재생()
    {
      SceneManager.LoadScene("GameTitle");
      SceneManager.LoadScene("GameSelect");
      SceneManager.LoadScene("GameOption");
      var obj = GameObject.Find("BGM_main").GetComponent<AudioSource>();
      Assert.IsTrue(obj.isPlaying);
    }

    public void 옵션창_클릭효과음()
    {
      GameObject obj1 = GameObject.Find("Button_1").GetComponent<AudioSource>();  // 밝기
      GameObject obj2 = GameObject.Find("Button_2").GetComponent<AudioSource>();  // 감도
      GameObject obj3 = GameObject.Find("Button_3").GetComponent<AudioSource>();  // 소리
      obj1.PlayOnClick();     클릭 시 사운드 재생 함수
      Assert.IsTrue(obj1.isPlaying);
      obj2.PlayOnClick();
      Assert.IsTrue(obj2.isPlaying);
      obj3.PlayOnClick();
      Assert.IsTrue(obj3.isPlaying);
    }
    ////////////////////////////
    //////현재 테스트 불가
    ////////////////////////////
    public void 옵션창_게임도중소리X()
    {

    }
    public void 옵션창_게임복귀소리()
    {

    }
    public void 결과창_UI출력()
    {

    }
    public void 결과창_리스트체크()
    {

    }
    public void 결과창_등급체크()
    {

    }
    public void 결과창_스테이지창진입()
    {

    }
    public void 결과창_음악재생()
    {

    }
    public void 결과창_클릭효과음()
    {

    }
    */
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]

    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

}

}
