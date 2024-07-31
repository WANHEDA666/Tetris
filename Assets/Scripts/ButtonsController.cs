using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    [SerializeField] private Transform canvas;
    [SerializeField] private GameObject AgreeScreen;
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject StatsScreen;
    [SerializeField] private GameObject SettingsScreen;
    [SerializeField] private GameObject LevelsScreen;
    [SerializeField] private GameObject GameScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject wonScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject lotteryScreen;
    [SerializeField] private GameObject webScreen;
     
    [SerializeField] private Button agreePanelButtonNo;
    [SerializeField] private GameObject agreePanelButtonYes;
    [SerializeField] private GameObject contAgreeNo;
    [SerializeField] private Button contAgreeYes;

    [SerializeField] private Button stats;
    [SerializeField] private Button settingsStartScreen;
    [SerializeField] private Button statsSettingsButton;
    [SerializeField] private Button contStartScreen;
    [SerializeField] private Button statsScreenBackButton;

    [SerializeField] private LevelButton[] levelButtons;
    [SerializeField] private Button levelsBack;
    [SerializeField] private Button levelsSettings;

    [SerializeField] private Button settingsScreenBack;
    [SerializeField] private Button menu;
    [SerializeField] private Button restart;
    [SerializeField] private Button pauseSettingsButton;

    [SerializeField] private Button wonHome;
    [SerializeField] private Button nextHome;
    [SerializeField] private Button restartHome;

    [SerializeField] private Button loseHome;
    [SerializeField] private Button loserestartHome;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Button lotteryBackButton;

    private GameScreen game;

    public void StartGame()
    {
        webScreen.SetActive(false);
        var isOn = PlayerPrefs.GetInt("audio") == 0;
        if (isOn)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
        if (PlayerPrefs.GetString("agree") == "yes")
        {
            StartPanel.SetActive(true);
        }
        else
        {
            AgreeScreen.SetActive(true);
        }
        
        lotteryBackButton.onClick.AddListener((() =>
        {
            lotteryScreen.gameObject.SetActive(false);
            LevelsScreen.gameObject.SetActive(true);
        }));
        
        loseHome.onClick.AddListener((() =>
        {
            loseScreen.gameObject.SetActive(false);
            game.pause.onClick.RemoveListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(true);
            }));
            game.settings.onClick.RemoveListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(false);
                SettingsScreen.SetActive(true);
            }));
            game.OnGameEnded -= b =>
            {
                if (b)
                {
                    if (PlayerPrefs.GetInt("level") < PlayerPrefs.GetInt("currentLevel") + 1)
                    {
                        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("currentLevel") + 1);
                    }
                    wonScreen.gameObject.SetActive(true);
                }
                else
                {
                    loseScreen.gameObject.SetActive(true);
                }
            };
            Destroy(game.gameObject);
            StartPanel.SetActive(true);
        }));
        
        loserestartHome.onClick.AddListener((() =>
        {
            loseScreen.gameObject.SetActive(false);
            game.pause.onClick.RemoveListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(true);
            }));
            game.settings.onClick.RemoveListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(false);
                SettingsScreen.SetActive(true);
            }));
            game.OnGameEnded -= b =>
            {
                if (b)
                {
                    if (PlayerPrefs.GetInt("level") < PlayerPrefs.GetInt("currentLevel") + 1)
                    {
                        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("currentLevel") + 1);
                    }
                    wonScreen.gameObject.SetActive(true);
                }
                else
                {
                    loseScreen.gameObject.SetActive(true);
                }
            };
            Destroy(game.gameObject);
            
            game = Instantiate(GameScreen, canvas).GetComponent<GameScreen>();
            game.pause.onClick.AddListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(true);
            }));
            game.settings.onClick.AddListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(false);
                SettingsScreen.SetActive(true);
            }));
            game.OnGameEnded += b =>
            {
                if (b)
                {
                    if (PlayerPrefs.GetInt("level") < PlayerPrefs.GetInt("currentLevel") + 1)
                    {
                        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("currentLevel") + 1);
                    }
                    wonScreen.gameObject.SetActive(true);
                }
                else
                {
                    loseScreen.gameObject.SetActive(true);
                }
            };
        }));
        
        restartHome.onClick.AddListener((() =>
        {
            wonScreen.gameObject.SetActive(false);
            game.pause.onClick.RemoveListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(true);
            }));
            game.settings.onClick.RemoveListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(false);
                SettingsScreen.SetActive(true);
            }));
            game.OnGameEnded -= b =>
            {
                if (b)
                {
                    if (PlayerPrefs.GetInt("level") < PlayerPrefs.GetInt("currentLevel") + 1)
                    {
                        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("currentLevel") + 1);
                    }
                    wonScreen.gameObject.SetActive(true);
                }
                else
                {
                    loseScreen.gameObject.SetActive(true);
                }
            };
            Destroy(game.gameObject);
            
            game = Instantiate(GameScreen, canvas).GetComponent<GameScreen>();
            game.pause.onClick.AddListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(true);
            }));
            game.settings.onClick.AddListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(false);
                SettingsScreen.SetActive(true);
            }));
            game.OnGameEnded += b =>
            {
                if (b)
                {
                    if (PlayerPrefs.GetInt("level") < PlayerPrefs.GetInt("currentLevel") + 1)
                    {
                        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("currentLevel") + 1);
                    }
                    wonScreen.gameObject.SetActive(true);
                }
                else
                {
                    loseScreen.gameObject.SetActive(true);
                }
            };
        }));
        
        nextHome.onClick.AddListener((() =>
        {
            wonScreen.gameObject.SetActive(false);
            game.pause.onClick.RemoveListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(true);
            }));
            game.settings.onClick.RemoveListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(false);
                SettingsScreen.SetActive(true);
            }));
            game.OnGameEnded -= b =>
            {
                if (b)
                {
                    if (PlayerPrefs.GetInt("level") < PlayerPrefs.GetInt("currentLevel") + 1)
                    {
                        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("currentLevel") + 1);
                    }
                    wonScreen.gameObject.SetActive(true);
                }
                else
                {
                    loseScreen.gameObject.SetActive(true);
                }
            };
            Destroy(game.gameObject);
            lotteryScreen.SetActive(true);
        }));
        
        wonHome.onClick.AddListener((() =>
        {
            wonScreen.gameObject.SetActive(false);
            game.pause.onClick.RemoveListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(true);
            }));
            game.settings.onClick.RemoveListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(false);
                SettingsScreen.SetActive(true);
            }));
            game.OnGameEnded -= b =>
            {
                if (b)
                {
                    if (PlayerPrefs.GetInt("level") < PlayerPrefs.GetInt("currentLevel") + 1)
                    {
                        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("currentLevel") + 1);
                    }
                    wonScreen.gameObject.SetActive(true);
                }
                else
                {
                    loseScreen.gameObject.SetActive(true);
                }
            };
            Destroy(game.gameObject);
            StartPanel.SetActive(true);
        }));
        
        agreePanelButtonNo.onClick.AddListener((() =>
        { 
            PlayerPrefs.SetString("agree", "yes");
            agreePanelButtonNo.gameObject.SetActive(false);
            agreePanelButtonYes.gameObject.SetActive(true);
            contAgreeNo.gameObject.SetActive(false);
            contAgreeYes.gameObject.SetActive(true);
        }));
        
        contAgreeYes.onClick.AddListener((() =>
        {
            AgreeScreen.SetActive(false);
            StartPanel.SetActive(true);
        }));

        stats.onClick.AddListener(() =>
        {
            StartPanel.gameObject.SetActive(false);
            StatsScreen.gameObject.SetActive(true);
        });

        settingsStartScreen.onClick.AddListener(() =>
        {
            SettingsScreen.gameObject.SetActive(true);
        });

        contStartScreen.onClick.AddListener(() =>
        {
            StartPanel.gameObject.SetActive(false);
            LevelsScreen.gameObject.SetActive(true);
        });

        //var levelsEnabled = PlayerPrefs.GetInt("level");
        for (int i = 0; i < levelButtons.Length; i++)
        {
            // if (i > levelsEnabled)
            // {
            //     continue;
            // }
            // levelButtons[i].Open();
            var i1 = i;
            levelButtons[i].button.onClick.AddListener((() =>
            {
                PlayerPrefs.SetInt("currentLevel", levelButtons[i1].levelIs);
                LevelsScreen.gameObject.SetActive(false);
                game = Instantiate(GameScreen, canvas).GetComponent<GameScreen>();
                game.pause.onClick.AddListener((() =>
                {
                    game.board.activePiece.locks = true;
                    pauseScreen.SetActive(true);
                }));
                game.settings.onClick.AddListener((() =>
                {
                    game.board.activePiece.locks = true;
                    pauseScreen.SetActive(false);
                    SettingsScreen.SetActive(true);
                }));
                game.OnGameEnded += b =>
                {
                    if (b)
                    {
                        if (PlayerPrefs.GetInt("level") < PlayerPrefs.GetInt("currentLevel") + 1)
                        {
                            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("currentLevel") + 1);
                        }
                        wonScreen.gameObject.SetActive(true);
                    }
                    else
                    {
                        loseScreen.gameObject.SetActive(true);
                    }
                };
            }));
        }
        
        levelsBack.onClick.AddListener((() =>
        {
            StartPanel.gameObject.SetActive(true);
            LevelsScreen.gameObject.SetActive(false);
        }));
        
        levelsSettings.onClick.AddListener((() =>
        {
            SettingsScreen.gameObject.SetActive(true);
        }));
        
        settingsScreenBack.onClick.AddListener((() =>
        {
            SettingsScreen.gameObject.SetActive(false);
            if (game != null)
            {
                game.board.activePiece.locks = false;
            }
        }));
        
        statsSettingsButton.onClick.AddListener((() =>
        {
            SettingsScreen.gameObject.SetActive(true);
        }));
        
        statsScreenBackButton.onClick.AddListener((() =>
        {
            StatsScreen.gameObject.SetActive(false);
            StartPanel.gameObject.SetActive(true);
        }));
        
        menu.onClick.AddListener((() =>
        {
            game.pause.onClick.RemoveListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(true);
            }));
            game.settings.onClick.RemoveListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(false);
                SettingsScreen.SetActive(true);
            }));
            game.OnGameEnded -= b =>
            {
                if (b)
                {
                    if (PlayerPrefs.GetInt("level") < PlayerPrefs.GetInt("currentLevel") + 1)
                    {
                        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("currentLevel") + 1);
                    }
                    wonScreen.gameObject.SetActive(true);
                }
                else
                {
                    loseScreen.gameObject.SetActive(true);
                }
            };
            Destroy(game.gameObject);
            pauseScreen.SetActive(false);
            StartPanel.SetActive(true);
        }));
        
        restart.onClick.AddListener((() =>
        {
            pauseScreen.SetActive(false);
            game.pause.onClick.RemoveListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(true);
            }));
            game.settings.onClick.RemoveListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(false);
                SettingsScreen.SetActive(true);
            }));
            game.OnGameEnded -= b =>
            {
                if (b)
                {
                    if (PlayerPrefs.GetInt("level") < PlayerPrefs.GetInt("currentLevel") + 1)
                    {
                        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("currentLevel") + 1);
                    }
                    wonScreen.gameObject.SetActive(true);
                }
                else
                {
                    loseScreen.gameObject.SetActive(true);
                }
            };
            Destroy(game.gameObject);
            
            game = Instantiate(GameScreen, canvas).GetComponent<GameScreen>();
            game.pause.onClick.AddListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(true);
            }));
            game.settings.onClick.AddListener((() =>
            {
                game.board.activePiece.locks = true;
                pauseScreen.SetActive(false);
                SettingsScreen.SetActive(true);
            }));
            game.OnGameEnded += b =>
            {
                if (b)
                {
                    if (PlayerPrefs.GetInt("level") < PlayerPrefs.GetInt("currentLevel") + 1)
                    {
                        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("currentLevel") + 1);
                    }
                    wonScreen.gameObject.SetActive(true);
                }
                else
                {
                    loseScreen.gameObject.SetActive(true);
                }
            };
        }));
        
        pauseSettingsButton.onClick.AddListener((() =>
        {
            pauseScreen.SetActive(false);
            SettingsScreen.SetActive(true);
        }));
    }
}