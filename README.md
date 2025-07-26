# MossWork

## 소개

**MossWork**는 방향키와 스페이스바 그리고 마우스 클릭을 활용하여 간단하게 조작가능한 게임입니다.  
맵을 여행하고 미니게임을 즐기며 점수를 획득하는 게임입니다. 
Unity로 개발되었으며 모바일과 PC에서 플레이할 수 있도록 설계되었습니다.

---

## 주요 기능

- **캐릭터 이동 및 맵 탐색**  
  WASD 또는 화살표 키를 사용하여 2D 캐릭터가 자유롭게 이동가능합니다.
  스페이스바를 활용하여 점프가 가능합니다.

- **맵 설계 및 상호작용**  
  타일맵을 활용하여 간단한 맵이 설계되어 있습니다.
  특정영역에 도달할 경우 상호작용 이벤트가 발생합니다.

- **미니 게임**  
  플래피버드를 오마쥬한 미니게임이 있습니다.

- **점수 시스템**  
  미니게임의 점수를 기록하고 표시합니다.

- **게임 종료 및 복귀**  
  미니게임에서 다시 메인으로 돌아갈 수 있는 로직을 구현하였습니다.

- **카메라 추적**  
  카메라는 플레이어를 자연스럽게 따라옵니다.

---

## 폴더 및 주요 파일 구조
TextRPG_TeamSix/

├── BGLooper / # MiniGameScene / Obstacle과 충돌시 Obstacle을 재배치 시켜주는 로직  
├── GameManager / # MiniGameScene / 게임의 상태와 점수, UI 갱신 등 전반적인 흐름을 제어
├── MiniGamePlayer / # MiniGameScene / 플레이어 캐릭터의 이동 및 점프 제어, 애니메이션 및 물리 처리, 게임 오버 및 재시작 처리, 기타 기능
├── MiniGameStartR / # MainScene / 활성화 되었을때 R키를 누르면 MiniGameScene으로 이동
├── Obstacle / # MiniGameScene / 장애물 위치를 설정, 플레이어 점수 처리
├── PlayerCamera / # MainScene, MiniGameScene / 지정된 대상을 따라가는 카메라 기능
├── PlyaerController2D / # MainScene / 이동 처리, 점프 처리, 애니메이션 좌우 반전 처리
├── QuestTrigger / # MainScene / 이벤트에 활용, 충돌 범위에 속해질 경우 특정 이벤트 활성화, 벗어날 경우 비활성화
├── ScoreText / # MainScene / UI패널 관리, 최고점수 표시, Exit 버튼 동작 (미구현)
└── UIManager / # MiniGameScene / 점수 및 최고점수 관리, UI 상태 제어, 점수 갱신, 게임안내, ESC로 메인 씬 이동

---

## 에셋 활용

├── 2D Forest sprite pack / # MiniGameScene / Background 및 obstacle에 이미지 활용
└── Pixel Art Top Down - Basic / # MainScene / 타일맵 활용 및 상호작용 기물 설치

---

## 개발 환경

- Unity 2022.3.17f 활용  
