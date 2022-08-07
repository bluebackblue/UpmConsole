# BlueBack.Console
コンソール操作
* ファイル出力
* syslog udp 送信

## ライセンス
MIT License
* https://github.com/bluebackblue/UpmConsole/blob/main/LICENSE

## 依存 / 使用ライセンス等
### ランタイム
* https://github.com/bluebackblue/UpmJsonItem
### エディター
* https://github.com/bluebackblue/UpmConsole
* https://github.com/bluebackblue/UpmAssetLib
* https://github.com/bluebackblue/UpmJsonItem
### サンプル
* https://github.com/bluebackblue/UpmConsole

## 動作確認
Unity 2022.1.0b16

## UPM
### 最新
* https://github.com/bluebackblue/UpmConsole.git?path=BlueBackConsole/Assets/UPM#0.0.11
### 開発
* https://github.com/bluebackblue/UpmConsole.git?path=BlueBackConsole/Assets/UPM

## Unityへの追加方法
* Unity起動
* メニュー選択：「Window->Package Manager」
* ボタン選択：「左上の＋ボタン」
* リスト選択：「Add package from git URL...」
* 上記UPMのURLを追加「 https://github.com/～～/UPM#バージョン 」
### 注
Gitクライアントがインストールされている必要がある。
* https://docs.unity3d.com/ja/current/Manual/upm-git.html
* https://git-scm.com/

## デファイン
### DEF_BLUEBACK_CONSOLE_DISABLE
 * 機能を無効化する。
### DEF_BLUEBACK_CONSOLE_FILE_DISABLE
 * ファイル出力を無効化する。
### DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE
 * 送信を無効化する。
### DEF_BLUEBACK_CONSOLE_INSTALL_DISABLE
 * エディター起動時の自動インストールを無効化する。
### DEF_BLUEBACK_CONSOLE_RUNTIMEINITIALIZE_DISABLE
 * ゲーム開始時の初期化を無効化する。
### DEF_BLUEBACK_CONSOLE_INITIALIZEONLOAD_DISABLE
 * エディター起動時の初期化を無効化する。
### DEF_BLUEBACK_CONSOLE_BUILDPIPELINE_DISABLE
 * ビルド時の初期化を無効化する。

