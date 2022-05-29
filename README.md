# dart-watcher

DART에 올라오는 공시 중, 정해진 Keyword를 포함한 공시가 올라오면 Windows Toast 메시지를 발생시켜주는 앱입니다.
반드시 configs/config.xml에 있는 api-key를 본인 키로 변경해야 동작합니다.

## 기능
15초마다 DART 공시를 가져와서 Keyword를 포함한 공시가 있는지 확인하고, Toast 메시지로 알려줍니다. Toast 메시지를 클릭하면 해당 공시로 이동합니다.

## 키 발급 방법

1. https://opendart.fss.or.kr/ 접속합니다.
2. 인증키 신청/관리 >  인증키 신청에서 인증키를 신청합니다.
3. 신청을 완료하면, "오픈API 이용현황"에서 본인의 API Key를 복사합니다.
4. configs/config.xml에 해당 키를 붙여넣기 합니다.