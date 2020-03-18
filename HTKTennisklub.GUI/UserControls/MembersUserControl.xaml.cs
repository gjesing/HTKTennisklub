using HTKTennisklub.DAL;
using HTKTennisklub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HTKTennisklub.GUI.UserControls
{
    /// <summary>
    /// Interaction logic for MembersUserControl1.xaml
    /// </summary>
    public partial class MembersUserControl : UserControl
    {
        public List<Member> members { get; set; } = new MemberRepository().GetMembers();
        public MembersUserControl()
        {
            InitializeComponent();
            memberList.ItemsSource = members;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            new Window { Title = "Rediger medlem", Content = new UpdateMemberUserControl((Member)memberList.SelectedItem), Width = 350, SizeToContent = SizeToContent.Height, WindowStartupLocation = WindowStartupLocation.CenterScreen }.ShowDialog();
            members = new MemberRepository().GetMembers();
            memberList.ItemsSource = members;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Member member = (Member)memberList.SelectedItem;
            MessageBoxResult result = MessageBox.Show($"Slet medlem \"{member.FirstName} {member.LastName}\"?", "Slet medlem", MessageBoxButton.OKCancel);
            switch (result)
            {
                case MessageBoxResult.OK:
                    MemberRepository memberRepository = new MemberRepository();
                    memberRepository.MakeMemberInactive(member);
                    MessageBox.Show($"{member.FirstName} {member.LastName} er fjernet fra medlemslisten.");
                    members = memberRepository.GetMembers();
                    memberList.ItemsSource = members;
                    break;
                case MessageBoxResult.Cancel:
                    break;
                default:
                    break;
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            new Window { Title = "Opret medlem", Content = new CreateMemberUserControl(), Width = 350, SizeToContent = SizeToContent.Height, WindowStartupLocation = WindowStartupLocation.CenterScreen }.ShowDialog();
            members = new MemberRepository().GetMembers();
            memberList.ItemsSource = members;
        }
    }
}
