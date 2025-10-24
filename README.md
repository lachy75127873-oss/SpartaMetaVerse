# 🧱 Sparta Metaverse (Unity 2022.3.62f2)

> ZEP처럼 맵에서 이동하고, 상호작용 존을 통해 미니 게임(플래피버드 or 스택)을 실행하는 2D 미니 게임 프로젝트.  
> 이번 단계에서는 **프로젝트 기본 구조(스켈레톤)** 및 GitHub 관리 체계를 구축합니다.

---

## 🎯 프로젝트 개요
- **프로젝트 이름:** Sparta Metaverse 2D
- **개발 환경:** Unity 2022.3.62f2 (Built-in RP)
- **IDE:** Rider / VS Code (자유)
- **플랫폼:** PC (WebGL은 후순위)
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
Assets/
└─ _Project/
├─ Core/ # 씬 전환, 이벤트, 세이브 어댑터 등 공통 로직
├─ Systems/
│ ├─ Movement/ # 플레이어 이동/경계
│ ├─ Interaction/ # 상호작용 존/프롬프트
│ ├─ MiniGameFramework/ # 미니게임 수명주기/결과 DTO
│ ├─ Score/ # 점수 및 최고점 관리
│ └─ Camera/ # 카메라 추적/경계
├─ UI/
│ ├─ Common/ # 공용 HUD, 팝업
│ ├─ Overworld/ # 맵 전용 UI
│ └─ MiniGames/ # 미니게임 전용 UI
├─ Scenes/
│ ├─ Bootstrap.unity # 매니저/오케스트레이션
│ ├─ Overworld.unity # 맵/상호작용 존
│ ├─ MiniGame_Flappy.unity
│ └─ MiniGame_Stack.unity
├─ Prefabs/
│ ├─ Player/
│ ├─ Interactables/
│ ├─ MiniGameEntrances/
│ └─ Managers/
├─ ScriptableObjects/
└─ Art/
├─ Audio/
└─ ThirdParty/
```


---

## 🔄 브랜치 전략

> main 최종 제출용 (배포/데모) 
> develop 통합, 테스트용 
> feature 기능 단위 개발 (예: `feature/skeleton-setup`) 

---

## 🧰 커밋 컨벤션
| feat | `feat: add player movement logic` | 새로운 기능 추가 |
| fix | `fix: resolve camera follow bug` | 버그 수정 |
| chore | `chore: update .gitignore` | 설정, 빌드 관련 작업 |
| docs | `docs: update README` | 문서 작성/수정 |
| refactor | `refactor: simplify battle system` | 리팩터링 |
| rename |

---

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

## ✅ 1단계 완료 기준 (DoD)
- `.gitignore`가 올바르게 작동 (`Library`, `Temp`, `Logs` 미추적)
- README.md, PR 템플릿 정리 완료
- 스켈레톤 폴더/씬/프리팹 자리 생성 완료
- `feature/skeleton-setup` → `develop`으로 PR 머지 성공

---

## 🗓️ 다음 단계 (예고)
**2단계 – Player 이동 및 카메라 추적 구현**  
- Movement System 작성  
- Camera Follow & Boundary 기능 추가  
- Interaction Zone 설계 준비
