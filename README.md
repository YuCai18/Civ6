# 本仓库建立目的

之前自己的代码都是分项目上传的，分的比较散。因为其实大部分并不算严格意义的开源项目，所以每次都单开个 repository 感觉有点浪费。这里直接建立一个总的 Git 仓库，可以统一上传各种不同语言的不同项目代码，某种程度来说，也算是将 Git 和项目解耦。

# 仓库建立过程

在目录下执行下面命令建立本地仓库：

```shell
git init
```

检查当前文件状态（会显示未跟踪文件）：

```shell
git status
```

跟踪新文件\暂存文件更新：

```shell
git add README.md
```

> 这是个多功能命令：可以用它开始跟踪新文件，或者把已跟踪的文件放到暂存区，还能用于合并时把有冲突的文件标记为已解决状态等。

查看未暂存的内容：

```shell
git diff
```

查看已暂存的将要添加到下次提交里的内容：

```shell
git diff --cached
```

> （Git 1.6.1 及更高版本还允许使用 `git diff --staged`，效果是相同的，但更好记些。）

提交更新：

```shell
git commit
```

这种方式会启动文本编辑器以便输入本次提交的说明。

> 你也可以在 `commit` 命令后添加 `-m` 选项，将提交信息与命令放在同一行
>
> 只要在提交的时候，给 `git commit` 加上 `-a` 选项，Git 就会自动把所有已经跟踪过的文件暂存起来一并提交，从而跳过 `git add` 步骤
