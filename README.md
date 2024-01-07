## Save-Load


<p align = "center"><img src="https://jidaeportfolio.s3.ap-northeast-2.amazonaws.com/SaveAndLoadFlowChart.jpg" height = "400px" weight = "100px">
</p>


## UML


<p align = "center"><img src="./image/Save&Load_UML.PNG" height = "400px" weight = "100px">
</p>

  
### 개발과정
- 게임 기획 단계에서 RPG의 성장 재미를 가져올 수 있는 부분이 어떤 부분이 있을까 팀원들과 의견을 나눠 Save를 통해 플레이어가 얻은 아이템, 던전 레벨 등의 정보를 저장하여
    
    다음에 플레이 할 때 `이어할 수 있게 한다면 성장 재미를 느낄 수 있을 것 같다는 의견이 나와 Save & Load를 구현`하게 되었습니다.
    
- 서버가 따로 존재하지 않는 게임이기에 로컬 저장 방식을 `기존 인벤토리 개발 과정에서 공부했던 직렬화, 역직렬화, JsonUtility를 응용하여 구현`하였습니다.
- Load 부분에 있어 필요로 하는 플레이어가 착용중인 무기, 던전 레벨 등의 정보들을 `SaveData Class를 생성하여 Save 단계에서 직렬화를 통해 Json 파일로 저장하였고 Load 단계에서 Json파일을 SaveData 객체로 역직렬화해 정보를 입혀주는 식으로 구현`하게 되었습니다.


### 간단한 클래스 설명


${\textsf{\color\{red}Ctrl + 클릭을 통해 새창열기로 쉽게 코드를 확인하실 수 있습니다.}}$


- [**InvenItem.cs**](https://github.com/shji0318/Inventory/blob/main/InvenItem.cs)
  - 아이템에 대한 정보와 인벤토리 창에서 작용할 Use함수를 포함하고 있는 스크립트
  - 무기에 대한 장착 및 교체 부분 (Use() 부분)
  - player 정보와 image 정보를 초기화해주는 부분 (Init() 부분)
 

 
- [**SlotDragEvent.cs**](https://github.com/shji0318/Inventory/blob/main/SlotDragEvent.cs)
  - Drag & Drop 발생 시, Drag를 시작한 Slot의 정보 저장과 Slot간에 정보 변경 작업을 위한 스크립트
    - Drag를 시작하는 오브젝트와 Drop이 되는 곳에 오브젝트가 다르기에 정보를 저장해 놓기 위한 스크립트
  - DragSlot 과 DropSlot에 정보를 통해 정보 변경 작업을 하는 함수 (ChangeSlotItem (Slot) 부분) 
