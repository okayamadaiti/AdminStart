# AdminStart
他exeを管理者権限で実行します。

## 使い方
exeと同階層にtarget.iniを配置します。
target.iniには管理者権限で実行したいexeのパスを記述します。
(空白文字やダブルクォーテーションへの対応はしていないのでご注意ください)

## ソリューション構成
* AdminStartNet…….Net 5.0
* AdminStartNetFramework…….Net Framewok 制。
両者とも動作は変わりません。
軽量なexeで動作させたい場合は.Net Framework版をご利用ください。

## 技術
app.manifestの記述に従いUAC環境下での管理者権限で実行しているだけです。
特殊な技術は使用しておりません。


