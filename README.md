# 🧱 Sparta Metaverse (Unity 2022.3.62f2)

> ZEP처럼 맵에서 이동하고, 상호작용 존을 통해 미니 게임(플래피버드 or 스택)을 실행하는 2D 미니 게임 프로젝트.  

---

## 🎯 프로젝트 개요
- **프로젝트 이름:** Sparta Metaverse 2D
- **개발 환경:** Unity 2022.3.62f2 (Built-in RP)
- **IDE:** Rider / VS Code (자유)
- **진행 방식:** GitHub Flow 기반 브랜치 전략  
  `main → develop → feature/*`

---

## 🧩 핵심 목표 (1단계)
1. GitHub 레포지토리 초기화 (.gitignore / README / PR 템플릿)
2. 기본 브랜치 구조 생성  
   - `main` : 제출용 안정 브랜치  
   - `develop` : 통합 / 테스트용  
   - `feature/skeleton-setup` : 스켈레톤 세팅 브랜치
3. Unity 프로젝트 생성 및 정리 (.gitignore 적용)
4. 폴더/씬/프리팹 기본 구조 세팅
5. 첫 Pull Request 생성 및 Merge

---

## 📁 폴더 구조 (Skeleton Plan)
```

```


---

## 🔄 브랜치 전략

> main 최종 제출용 (배포/데모) 
> develop 통합, 테스트용 
> feature 기능 단위 개발 (예: `feature/skeleton-setup`) 

---

## 🧰 커밋 컨벤션
Add : 기능 구현, 혹은 게임 오브젝트 추가
Fix : 버그, 오류, 수정
Change : 이외에 리팩토링, 디자인 및 UI 수정 등

---

(이번 과제에는 적용X)
## 🚀 PR(Pull Request) 규칙
1. **feature/** 브랜치 단위로 PR 생성  
2. PR 제목: `feat: add project skeleton (folders/scenes/prefabs)`
3. PR 본문 구조:

What

폴더/씬/프리팹 스켈레톤 구성

Why

이후 기능 확장을 고려한 기본 구조 설계

Impact

씬 추가: Bootstrap, Overworld, MiniGame_Flappy, MiniGame_Stack

Next

feature/player-move-camera


---

