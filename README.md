# garimuki_05
- 共同制作している「garimuki」のリポジトリ
- 素材、コードのみを管理

## アプリ概要
- スマホの位置情報に合わせて、地図上を移動するいわゆる「位置ゲー」
- 今まで歩いてきた道の情報が足跡として残る
- 移動した距離に応じて、キャラクターがガリガリからムキムキになる

## 作業の流れ
コードを更新する方法
- チーム作業のやり方
    1. issueを作成
        - issuesからnew issueを押す
        - タイトルにやることを、Writeに何を具体的にするかを書く
        - Submit new issueでissueを立てる
    2. (mainブランチから始める)
        - git checkout main ブランチをmainに (プルリク出した後コード書き換えると元に戻れないので、2のgit add~を行ってください)
        - git branch --set-upstream-to=origin/<branch> main 現在のブランチのトラッキング情報を設定
        - git pull mainブランチの更新があるか確認する.これをすると反映されます
    3. featureブランチで開発
        - git checkout -b feature/{name} ブランチを作って移動する,既にブランチを作ってるなら-bは不要です
        - git branchで今いるブランチを確認できます
        - git add 追加するファイル
        - git commit -m "メッセージ"
            - 書式
                - [add/fix/update/remove] #num 内容
            - メッセージの種類
                1. fix バグ修正
                2. add 新規ファイル
                3. update コード追加
                4. remove 削除
        - git push origin feature/{name}
    4. pull requestを出す
        - githubのリポジトリページに飛ぶ
        - code->branch->new pull request->referenceからissueと関連付ける ->create pull request
        - 許可をもらえたらmergeする
    5. issueを閉じる

# コーディングルール
        
    
        



