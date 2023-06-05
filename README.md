# garimuki_05
- 共同制作している「garimuki」のリポジトリ
- 素材、コードのみを管理

## 作業の流れ
コードを更新する方法
- main直接いじる(最初以外やっちゃだめ)
    1. git add .　ファイル追加
    2. git commit -m "メッセージ" 差分更新
    3. git push origin main push

- チーム作業のやり方
    0. issueを作成
        - issuesからnew issueを押す
        - タイトルにやることを、Writeに何を具体的にするかを書く
        - Submit new issueでissueを立てる
    1. (mainブランチから始める)
        - git checkout main ブランチをmainに
        - git branch --set-upstream-to=origin/<branch> main 現在のブランチのトラッキング情報を設定
        - git pull mainブランチの更新があるか確認する
    2. featureブランチで開発
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
    3. pull requestを出す
        - githubのリポジトリページに飛ぶ
        - compare & pull requestを押す
        - 許可をもらえたらmergeする
    4. issueを閉じる
        
    
        



