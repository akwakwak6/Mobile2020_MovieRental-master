using DAL.model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductWebAPI.Infrastructure {
    public class TokenService
    {
        const string passPhrase = "YQYKnM7TVmf!6dcX?nswXL3gDg_Xf-fv48LUnBW?w3yDm*YEG_nRF_GLLHTpUHD8uk@Tg_@-=h9Nmh!2m$-24ff6J%Hsgfbq*bXWayUaRU52=L2e!jpt=Dty3L^Gd@H6rUcTJ=F-j*NTzQkBg4@#d6ewuwKYte33Z-TJ4FsC4B_^j7YZ5_E+!EHGgXqzEKbx=LQ*6q8TAmGAXTgwaFVD$DL+QXU#pvSgwNUG*rmQ*v=?yZus%JR+#xLwZ7%%YV8peqq-5XqTJq&ta@VN!U^PB+=ZAe?_rK+4P2Vx5uEH_hv4mBm-@%4rS4TEPpzdBh*Dm95$97ZdgyVz8zA?en*9hhUzpKqK7bv5R=V#NXEqZ98UD_X9vpCSu7*XUp-QRYzL-Wne5rM$QHMSRR#zZ-F#9gunZm!S-!wQsxF26y8*D_hR&Px=5_3+R*kuSBc6U3xxN@-mdh#HJJnfaaP!g@J@?MyFvA+?qe&Mm-&4u!42sTU_K@5QKnLWpRzycfS?@aRB*jDUKB$2yuF8#yf@F%=$4=ArNg#@8^5^TyBAWveh*GyEmZUzppM^AXkJyUB8a%K5g%6HTx#4XD&U8cg-jrH2?^+5M#HD587%aLD@S+KGP-=S$eS!Cb_7?=UYsw+7bH@=s+wA_GxY#7DxARpvBpWMQr&fAQgGTG+tHEmVSgy?!EE^ZeqfUk^yR5#_esEb7kweqk8c-uHpnQe4^3Rv=2UCP+$+t3%EmV^wzk5Sc*RW3EjXKtf$E!TU5ZCVHAMtWCeHn=*5MZKsj2EgL6FKeHvv=?Vp3q+#748$m8fP7HETP%z8Ej6K2fBCHyxbAt-qa@KWD?ZnPBMxk4wwmkKAHq?dFa8veGjY73C%g%H%4pDVW#bSN3*G4*W5F5*zDm!D_49SJFMW?@dQ?n6YsqvpP$VpfqdrDKjA#KDkw8s64Ad4&y2&gK^Z_ZCyc*kD+#5FyA*39vKEJhe9jy%C#Hm6B&KMdQ7ynYKmRErH3XRgbVJsPrp=6Hy9^7Fg8%VYQ?DEZY5TdqwuF_M-rXZ-RreX&mGx?KK!f-swqFBn!@peRLf4hyQtpf?WHQL?Mktrj+C7FjWUuAYDJb5*_mk9=N+yP$sdJ92_S!m^h7ad!EjhMY&?a-NG%8aTK#ZMG8+-tVNPX+JA%CyEpu#dV^tDnZZ4C#r#pdgNb@=@agG@&A$$JF+JyQV##=&QbF%2AHtL!zUFCa+mxGs!tH7b@Gh#a$_vfyZ$Jm2U$@=5uDEh&gnZ#QDas^#7+t!VWte-VH8qUr!hkcQXd2YNYuNJ&qrvJ%USd^%*r&ZreRhpXr$VzQuLk6=m_vymXAm*^64s#N*y@#qUW_r#5sDS?bq8yR2Qu5JYE=?_@9P5^uqqG?RnCLJPpkHGsY?_f2CCXhrR+Yx^L4=#FY47#8f@s^B$mxhMDqeY#vd_JsTdtCURVKKpBvqN#Yrb5&rr*KvwXV=M^-2dtDEGtR7AK2Wx!XFP%b@QU5vpGPv36yKbD#^Br2kV%d#cpe-BupfmnBcrG4ANW=-Z6RCr#%8pH#UCD8UkYQD+Bzg@DKW+F*fL^Yx&9=FX2Td9RjY?JyT?_TKY8B7DLdv8?&?F_Z&*7E=cxcdj-R?Hv9tGL*w4=XsDCPMDpCA+r+G^trcgfe=@5Lmm24MsMd-QjbEhfmaA+QWThvCFBaD#3*%hAG5KW=9AM5sJykp_XuUPJw=FYDQEM3yw#37pmX@Ra*FZtsUkXpSUs=Zuwh8qmwSzfJ3Pz=??aYMzPeeZJW?M_yVjrm3c425c$96NE8p#v*$!=vnR*wWTz!&SgfQE2+wUwTfrK$@wz-@%@CjQ2tsEBxPfqjm?7W9L6K@mfPR+jz_rHCQTEKBqP-LQ6s%WmH!Dw9g9V3nE2U^TxhJpem!7+V@2=jWP7BDpxUwt-Jkmz_$Ha_LnHXc?T*Lt*sKc$?DRL@j$qTbk^Bt%zNdv6Hb4=33XpMdy9B#&FK=EV+d2#4rVWvYjbqYrM8XwHAQ_5nwXQUx&8d8UrK^^RPVaaSd-JakaswT3s_L$Zc#k#VMjfF8@jf&B";

        private JwtSecurityTokenHandler _handler;
        private JwtHeader _header;

        public JwtSecurityTokenHandler Handler
        {
            get
            {
                return _handler ??= new JwtSecurityTokenHandler();
            }
        }

        public JwtHeader Header
        {
            get
            {
                if(_header is null)
                {
                    byte[] key = Encoding.UTF8.GetBytes(passPhrase);
                    SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(key);
                    SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);
                    _header = new JwtHeader(signingCredentials);
                }

                return _header;
            }
        }

        public int getCustomerId(string token) {

            token = token.Replace("Bearer ", "");
            new JwtSecurityToken(token).Payload.TryGetValue("Id", out object id);
            return int.Parse((string)id);
        }

        public string GenerateToken(Customer c)
        {
            JwtSecurityToken securityToken = new JwtSecurityToken(
                Header,
                new JwtPayload(
                    issuer: "Product Web Api",
                    audience: null,
                    claims: new Claim[]
                    {
                        new Claim("Id", c.Id.ToString()),
                        new Claim("Nom", c.LastName),
                        new Claim("Prenom", c.FirstName)
                    },
                    notBefore:DateTime.Now,
                    expires:DateTime.Now.AddDays(1))
                );


            return "Bearer " + Handler.WriteToken(securityToken);
        }

        public Customer VerifyToken(string token)
        {
            if (token.StartsWith("Bearer "))
                token = token.Replace("Bearer ", "");

            Customer user = null;
            JwtSecurityToken securityToken = new JwtSecurityToken(token);

            if(securityToken.ValidFrom <= DateTime.Now && securityToken.ValidTo >= DateTime.Now)
            {
                JwtPayload payLoad = securityToken.Payload;
                string test = Handler.WriteToken(new JwtSecurityToken(Header, payLoad));

                if(token == test)
                {
                    payLoad.TryGetValue("Id", out object id);
                    payLoad.TryGetValue("Nom", out object lastName);
                    payLoad.TryGetValue("Prenom", out object firstName);

                    user = new Customer()
                    {
                        Id = int.Parse((string)id),
                        LastName = (string)lastName,
                        FirstName = (string)firstName
                    };
                }
            }

            return user;
        }
    }
}
